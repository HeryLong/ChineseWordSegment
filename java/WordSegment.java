package ChineseWordSegment;

import java.io.*;
import java.util.ArrayList;

/**
 * Chinese-Word-Segment-Factory, which can divide the input sentence into single words.
 * @author HeryLong
 * @time	2016.03.20
 */
public class WordSegment {
	
	// a singleton WordSegment instance
	private static WordSegment wordSegment = null;
	
	// the global wordNode instance
	private WordNode rootWordNode = null;
	
	private WordSegment(String tagString){
		// do additional initialize
		this.rootWordNode = new WordNode("");
	}
	
	public static WordSegment getInstance(String tagString) {
		if (WordSegment.wordSegment == null) {
			WordSegment.wordSegment = new WordSegment(tagString);
		}
		return WordSegment.wordSegment;
	}
	
	/**
	 * iterator all of words in the input dictionary file, and add them into rootWordNode
	 * @param pathString input dictionary file path
	 * @return WordSegment instance which has the dictionary already
	 */
	public WordSegment addDirectory(String pathString){
		try{
			File dicFile = new File(pathString);
			//check if the dictionary file is exist
			if (dicFile.isFile() && dicFile.exists()) {
				InputStreamReader read = new InputStreamReader(new FileInputStream(dicFile), "UTF-8");
				BufferedReader bufferedReader = new BufferedReader(read);
				String tmpStr = "";
				WordNode currentNode = this.rootWordNode;
				// iterator each words in the dictionary file
				while((tmpStr = bufferedReader.readLine()) != null) {
					for (int i = 0; i < tmpStr.length(); i++) {
						currentNode = currentNode.addSubNode(tmpStr.charAt(i)+"");
					}
					currentNode = this.rootWordNode;
				}
				read.close();
			}
		}catch(Exception e){
			return WordSegment.wordSegment;
		}
		
		return WordSegment.wordSegment;
	}
	
	/**
	 * segment the input sentence into separate word
	 * @param sentenceString input sentence to be segmented
	 * @return separated words
	 */
	public ArrayList<String> segmentSentence(String sentenceString) {
		ArrayList<String>	segments = new ArrayList<String>();
		String tmpWord = "";
		
		WordNode currentNode = this.rootWordNode;
		// iterate the input sentence
		for(int i=0;i<sentenceString.length();) {
			currentNode = currentNode.getSubWord(sentenceString.charAt(i) + "");
			// go into the following word
			if (currentNode != null) {
				tmpWord += sentenceString.charAt(i);
				i++;
			} else {
				// it is a word checked by the dictionary
				segments.add(tmpWord);
				tmpWord = "";
				currentNode = this.rootWordNode;
			}
		}
		// add the last word
		segments.add(tmpWord);
		
		return segments;
	}
	
}

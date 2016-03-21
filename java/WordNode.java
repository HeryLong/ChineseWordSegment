package ChineseWordSegment;

import java.util.HashMap;

/**
 * WordNode, hold a single character and the following characters
 * created by the input dictionary
 * @author HeryLong
 *
 */
public class WordNode {
	
	//	the single character
	private String word = null;
	
	// a HashMap for saving the following characters
	private HashMap<String, WordNode> subWords = null;
	
	public WordNode(String word){
		this.word = word;
		this.subWords = new HashMap<String, WordNode>();
	}
	
	/**
	 * add a following character into the HashMap
	 * @param subWord	input character by dictionary
	 * @return a WordNode with the input subWord key
	 */
	public WordNode addSubNode(String subWord) {
		WordNode subWordNode = null;
		// check if it has the input subWord already
		if (this.subWords.keySet().contains(subWord)) {
			subWordNode = this.subWords.get(subWord);
		} else {
			// if no, then create a new one, and add it into subWords
			subWordNode = new WordNode(subWord);
			this.subWords.put(subWord, subWordNode);
		}
		return subWordNode;
	}
	
	/**
	 * get the following character by the subWords
	 * @param subWord input character by dictionary
	 * @return a WordNode with the input subWord key or null
	 */
	public WordNode getSubWord(String subWord) {
		WordNode subWordNode = null;
		if (this.subWords.keySet().contains(subWord)) {
			subWordNode = this.subWords.get(subWord);
		}
		return subWordNode;
	}
}

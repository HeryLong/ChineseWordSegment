using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseWordSegment
{
    /// <summary>
    /// WordSegment, which can divide the input sentence into separate words
    /// </summary>
    public class WordSegment
    {
        // a singleton WordSegment instance
        private static WordSegment wordSegment = null;

        // the global wordNode instance
        private WordNode rootWordNode = null;

        private WordSegment(String tagString)
        {
            //do additional initialize
            this.rootWordNode = new WordNode("");
        }

        public static WordSegment getInstance(String tagString)
        {
            if(WordSegment.wordSegment == null)
            {
                WordSegment.wordSegment = new WordSegment(tagString);
            }
            return WordSegment.wordSegment;
        }

        /// <summary>
        /// iterator all of words in the input dictionary file, and add them into rootWordNode
        /// </summary>
        /// <param name="pathString">input dictionary file path</param>
        /// <returns>WordSegment instance which has the dictionary already</returns>
        public WordSegment addDirectory(String pathString)
        {
            if (File.Exists(pathString))
            {
                StreamReader sr = new StreamReader(pathString, Encoding.UTF8);
                String tmpStr = "";
                WordNode currentNode = this.rootWordNode;
                //iterator each words in the dictioanry file
                while((tmpStr = sr.ReadLine()) != null)
                {
                    for(int i = 0; i < tmpStr.Length; i++)
                    {
                        currentNode = currentNode.addSubNode(tmpStr[i].ToString());
                    }
                    currentNode = this.rootWordNode;
                }
                sr.Close();
            }
            return WordSegment.wordSegment;
        }

        /// <summary>
        /// segment the input sentence into separate word
        /// </summary>
        /// <param name="sentence">input sentence to be segmented</param>
        /// <returns>separated words</returns>
        public List<String> segmentSentence(String sentence)
        {
            List<String> segments = new List<String>();
            String tmpWord = "";

            WordNode currentNode = this.rootWordNode;
            // iterate the input sentence
            for(int i = 0; i < sentence.Length;)
            {
                currentNode = currentNode.getSubWord(sentence[i].ToString());
                // go into the following word
                if(currentNode != null)
                {
                    tmpWord += sentence[i].ToString();
                    i++;
                }
                else
                {
                    //it is a word checked by the dictionary
                    segments.Add(tmpWord);
                    tmpWord = "";
                    currentNode = this.rootWordNode;
                }
            }

            //add the last word
            segments.Add(tmpWord);

            return segments;
        }
    }
}

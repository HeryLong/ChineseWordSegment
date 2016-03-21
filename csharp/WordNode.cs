using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseWordSegment
{
    /// <summary>
    /// WordNode, hold a single character and the following characters
    /// craeted by the input dictionary
    /// </summary>
    class WordNode
    {
        // the single character
        private String word = null;

        //a Dictionary for saving the following characters
        private Dictionary<String, WordNode> subWords = null;

        public WordNode(String word)
        {
            this.word = word;
            this.subWords = new Dictionary<string, WordNode>();
        }

        /// <summary>
        /// add a following character into the Dictionary
        /// </summary>
        /// <param name="subWord">input character by dictionary</param>
        /// <returns>a WordNode with the input subWord key</returns>
        public WordNode addSubNode(String subWord)
        {
            WordNode subWordNode = null;
            // check if it has the input subWord already
            if(this.subWords.Keys.Contains(subWord))
            {
                subWordNode = this.subWords[subWord];
            }
            else
            {
                //if no, then create a new one, and add it into subWords
                subWordNode = new WordNode(subWord);
                this.subWords.Add(subWord, subWordNode);
            }
            return subWordNode;
        }

        /// <summary>
        /// get the folling character by the subWords
        /// </summary>
        /// <param name="subWord">input character by dictionary</param>
        /// <returns>a WordNode with the input subWord key or null</returns>
        public WordNode getSubWord(String subWord)
        {
            WordNode subWordNode = null;
            if(this.subWords.Keys.Contains(subWord))
            {
                subWordNode = this.subWords[subWord];
            }
            return subWordNode;
        }
    }
}

//
//  WordSegment.m
//  ChineseWordSegment
//
//  Created by HeryLong on 16/3/20.
//  Copyright (c) 2016年 com.herylong. All rights reserved.
//

#import "WordSegment.h"

// A root WordNode about all of the input dictionaries
static WordNode* rootWordNode = nil;

@implementation WordSegment

+(void) addDictionary:(NSString *)dictionaryFile {
    //if the rootWordNode is nil, then create it
    if (rootWordNode == nil) {
        rootWordNode = [[WordNode alloc] initWithWord:@""];
    }
    
    // check if the dictionaryFile exist
    if (![[NSFileManager defaultManager] fileExistsAtPath:dictionaryFile]) {
        return;
    }
    
    // iterate all the of the words, and create the full word-node
    NSArray* words = [[NSString stringWithContentsOfFile:dictionaryFile
                                               encoding:NSUTF8StringEncoding
                                                   error:NULL] componentsSeparatedByString:@"\n"];
    WordNode* currentNode = rootWordNode;
    // add all of the words into rootWordNode
    for (NSString* tmpWord in words) {
        for (int i=0; i<[tmpWord length]; i++) {
            currentNode = [currentNode addSubWord:
                           [NSString stringWithFormat:@"%C", [tmpWord characterAtIndex:i]]];
        }
        currentNode = rootWordNode;
    }
}

+(NSMutableArray*) segmentSentence:(NSString *)sentence {
    NSMutableArray* segments = [[NSMutableArray alloc] init];
    NSString* tmpWord = @"";
    
    // iterate the input sentence, and check a word by rootWordNode
    WordNode* currentNode = rootWordNode;
    for (int i=0; i<[sentence length];) {
        currentNode = [currentNode getSubWord:
                       [NSString stringWithFormat:@"%C", [sentence characterAtIndex:i]]];
        if (currentNode != nil) {
            tmpWord = [tmpWord stringByAppendingString:
                       [NSString stringWithFormat:@"%C", [sentence characterAtIndex:i]]];
            i++;
        }else{
            [segments addObject:tmpWord];
            tmpWord = @"";
            currentNode = rootWordNode;
        }
    }
    //the last separate word
    [segments addObject:tmpWord];
    
    return segments;
}

@end

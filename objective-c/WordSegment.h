//
//  WordSegment.h
//  ChineseWordSegment
//
//  WordSegment Class, to deal with the fellowing problems:
//  1: add new dictionary to the global Segmnet instance
//  2: segment the input sentence into seperate words
//
//  Created by HeryLong on 16/3/20.
//  Copyright (c) 2016年 com.herylong. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "WordNode.h"

@interface WordSegment : NSObject

//  Add a dictionary to the global segment instance
+(void) addDictionary:(NSString*) dictionaryFile;
//  Segment the input sentence into seperate words
+(NSMutableArray*) segmentSentence:(NSString*) sentence;

@end

//
//  WordNode.h
//  ChineseWordSegment
//
//  WordNode, hold a single character and the following characters
//        by a dictionary from the directory file
//
//  Created by HeryLong on 16/3/20.
//  Copyright (c) 2016年 com.herylong. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface WordNode : NSObject

// its character
@property (nonatomic, copy) NSString* word;
// its following characters created by the dictionary file
@property (nonatomic, strong) NSMutableDictionary* subWords;

// init a instance with its character
-(WordNode*) initWithWord:(NSString*) word;

//  add fellowing character from the dictionary file
-(WordNode*) addSubWord:(NSString*) subWord;
//  get following character, if exist
-(WordNode*) getSubWord:(NSString*) subWord;

@end

//
//  WordNode.m
//  ChineseWordSegment
//
//  Created by HeryLong on 16/3/20.
//  Copyright (c) 2016年 com.herylong. All rights reserved.
//

#import "WordNode.h"

@implementation WordNode

@synthesize word;
@synthesize subWords;

-(WordNode*) initWithWord:(NSString *)tmpWord {
    self = [super init];
    if (self) {
        self.word = tmpWord;
        self.subWords = [[NSMutableDictionary alloc] init];
    }
    return self;
}

-(WordNode*) addSubWord:(NSString *)subWord {
    WordNode* subWordNode = nil;
    // check the keys, whether it has the subWord already
    if ([self.subWords.allKeys containsObject:subWord]) {
        subWordNode = [self.subWords objectForKey:subWord];
    }else {
        // if not, then craete a new one and add it into subWords
        subWordNode = [[WordNode alloc] initWithWord:subWord];
        [subWords setObject:subWordNode forKey:subWord];
    }
    return subWordNode;
}

-(WordNode*) getSubWord:(NSString *)subWord {
    WordNode* subWordNode = nil;
    // get the subWordNode by the input subWord key
    if ([self.subWords.allKeys containsObject:subWord]) {
        subWordNode = [self.subWords objectForKey:subWord];
    }
    return subWordNode;
}

@end

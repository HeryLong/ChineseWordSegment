# ChineseWordSegment

### Introduction

This is a library to deal with the Chinese-Word-Segmentation issus.Actually, it can alse be used to deal with the segmentation issus of other languages, once you added the dictionary into the `WordSegment`. 

### Usage

Check the following details to integrate this library into your project.

##### Dictionary #####

There are several self-made-dictionaries, you can download them by clicking [self-made-dictionary](./self-made-dictionary). And call `addDictionary(string filePath)` to add them into you `WordSegment` instance.

##### For Objective-C #####

1: add all the files in [objective-c](./objective-c) to your project. 

2: add `import "WordSegment.h"` into the head file in the class you will use this library

3: call `[WordSegment addDictionary:dictionaryFile]` to add dictioanry file your download from [self-made-dictionary](./self-made-dictionary).

4: call `[WordSegment segment:sentence]` to segment the input sentence into seperate words.


##### For Java #####

1: add all the files in [java](./java) to your project. 

2: add `import ChineseWordSegment.WordSegment` in the class you will use this library, 

3: call `WordSegment.addDictionary(dictionaryFile)` to add dictioanry file your download from [self-made-dictionary](./self-made-dictionary).

4: call `WordSegment.segment(sentence)` to segment the input sentence into seperate words.


##### For CSharp #####

1: add all the files in [csharp](./csharp) to your project. 

2: add `using ChineseWordSegment.WordSegment` in the class you will use this library, 

3: call `WordSegment.addDictionary(dictionaryFile)` to add dictioanry file your download from [self-made-dictionary](./self-made-dictionary).

4: call `WordSegment.segment(sentence)` to segment the input sentence into seperate words.

##### For WebService #####

You can access this Segmentaton Server by sending a `GET`request at `http://218.241.10.190:8086/SegmentServer.svc/segments/测试内容` (replace the chinese content by yours). Notice, the segmentation results are not so correct , cause the server many not loads enough dictionary. 


### Contract ###
You can contract me with my email(herylong.ahu@gmail.com), or visit my facebook(https://www.facebook.com/people/Hery-Long/).

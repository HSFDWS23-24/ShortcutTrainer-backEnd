# API Documentation

This is the API desciption for oure Shortcut Trainer.

Table of contents:

- [general-description](#general-description)
    - [api-link](#api-link)
- [GET course](#get-course)
- [GET question](#get-question)
 ---

<a name="general-description"><a/>
## general description 
empty

---
<a name="api-link"><a/>
## API-Link 

Server Link: 
- https://hier_einfügen.de/api 

---

<a name="get-course"><a/>
## GET Course
### Description:
Displays all courses

### Request 
```
/Course
```

### Request body example
```
{
   "UserID": <integer>,
   "Category":"<string>",
   "Language":"<string>",
   "OperatingSystem":"<string>",
   "SearchString":"<string>",
   "Limit":"<string>"
}
```


### Responses body example
```
{
   "id":2,
   "title":"Beispielkurs 2",
   "language":"de",
   "description":"Beschreibung des Beispielkurses 2",
   "imageUrl":"url_zum_bild_2",
   "subscription":1,
   "tags":[
      {
         "tag":"Tag1"
      },
      {
         "tag":"Tag4"
      }
   ]
}
```
---
### Parameter definition
| IN/OUT | Variable        | Type   | Example                           | Description |
| ------ | --------------- | ------ | --------------------------------- | ----------- |
| IN     | UserID          | int32  | ?                                 |
| IN     | Category        | string | ?                                 |
| IN     | Language        | string | ?                                 |
| IN     | OperatingSystem | string | ?                                 |
| IN     | SearchString    | string | ?                                 |
| IN     | Limit           | int32  | ?                                 |
| OUT    | id              | int32  | 1357931                           |
| OUT    | title           | string | Beispielkurs 2                    |
| OUT    | language        | string | de                                |
| OUT    | description     | string | Beschreibung des Beispielkurses 2 |
| OUT    | imageUrl        | string | url_zum_bild_2                    |
| OUT    | subscription    | ?      | 1                                 |
| OUT    | tags            | array  |                                   |

&uarr; [back to top](#top)

---
<a name="get-question"><a/>
## GET question
### description:
request all question for one course


### Request 
```
/Question
```

### Request body example
```
{
   "CourseID":0,
   "Language":"?",
   "OperatingSystem":"?",
   "KeyboadLayout":"?"
}
```


### Responses body example
```
{
   ?
}
```

### Parameter definition
| IN/OUT | Variable        | Type   | Example | Description |
| ------ | --------------- | ------ | ------- | ----------- |
| IN     | CourseID        | int32  | ?       |
| IN     | Language        | string | ?       |
| IN     | OperatingSystem | string | ?       |
| IN     | KeyboadLayout   | string | ?       |
| OUT    |

&uarr; [back to top](#top)

---
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
   "UserID": 1,
   "Tag":"<string>",
   "Language":"en",
   "SubscriptionType":"0",
   "SearchString":"<string>",
   "Limit":"<string>"
}
```


### Responses body example
```
[
  {
    "id": 1,
    "title": "Beispielkurs 1",
    "language": "en",
    "description": "Beschreibung des Beispielkurses 1",
    "imageUrl": "url_zum_bild_1",
    "subscription": 0,
    "tags": [
      {
        "tag": "Tag1"
      },
      {
        "tag": "Tag2"
      }
    ],
    "isFavorite": true,
    "answeredCorrect": 2,
    "answeredIncorrect": 0,
    "amountQuestions": 3
  }
]
```
---
### Parameter definition
| IN/OUT | Variable        | Type   | Example                           | Description |
| ------ | --------------- | ------ | --------------------------------- | ----------- |
| IN     | UserID          | int32  | 1                                 | Default ohne angabe kommen zur zeit alle frei verfügbaren Kurse zurück
| IN     | Tag             | string | Tag1                              |
| IN     | Language        | string | en,de,fr                          | Default ohne angabe "de"
| IN     | SubscriptionType| int32  | 0(free), 1(other)                 | Default ohne angabe 0
| IN     | SearchString    | string | Beispielkurs 2                    |
| IN     | Limit           | int32  | 5                                 |
| OUT    | id              | int32  | 1                                 |
| OUT    | title           | string | Beispielkurs 1                    |
| OUT    | language        | string | en                                |
| OUT    | description     | string | Beschreibung des Beispielkurses 1 |
| OUT    | imageUrl        | string | url_zum_bild_1                    |
| OUT    | subscription    | int32  | 0(free)                           |
| OUT    | tags            | array  | "Tag1", "Tag2"                    |
| OUT    | isFavorite      | bool   | true                              |
| OUT    | answeredCorrect | int32  | 2                                 |
| OUT    | answeredIncorrect | int32  | 0                               | Die Nicht beantworteten Fragen können mit amountQuestions - answeredIncorrect - answeredCorrect berechnet werden
| OUT    | amountQuestions | int32  | 3                                 |

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

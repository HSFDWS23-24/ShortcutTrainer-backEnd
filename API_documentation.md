# API Documentation

This is the API desciption for oure Shortcut Trainer.

Table of contents:

- [general-description](#general-description)
    - [api-link](#api-link)
- [GET course](#get-course)
- [GET question](#get-question)
- [GET getUsers](#get-users)
- [GET getUser](#get-user)
- [POST addUser](#add-user)
- [POST updateUser](#update-user)
- [GET getUserCourses](#get-user-courses)
- [GET getUserCourse](#get-user-course)
- [POST addUserCourse](#add-user-course)
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
<a name="get-users"><a/>
## GET getUsers
### Description:
Displays all users

### Request 
```
/User/GetUsers
```

### Request body example
```
{
   
}
```


### Responses body example
```
{
   ?
}
```
---
### Parameter definition
| IN/OUT | Variable        | Type   | Example                           | Description |
| ------ | --------------- | ------ | --------------------------------- | ----------- |
| ?      | ?               | ?      | ?                                 | ?           |

&uarr; [back to top](#top)

---
<a name="get-user"><a/>
## GET getUser
### Description:
Displays single user

### Request 
```
/User/GetUser
```

### Request body example
```
{
   "UserID":"<string>"
}
```


### Responses body example
```
{
   ?
}
```
---
### Parameter definition
| IN/OUT | Variable        | Type   | Example                           | Description |
| ------ | --------------- | ------ | --------------------------------- | ----------- |
| IN     | UserID          | string | ?                                 | User ID     |

&uarr; [back to top](#top)

---
<a name="add-user"><a/>
## POST addUser
### Description:
Adds user to database

### Request 
```
/User/AddUser
```

### Request body example
```
{
   ?
}
```


### Responses body example
```
{
   ?
}
```
---
### Parameter definition
| IN/OUT | Variable        | Type   | Example                           | Description |
| ------ | --------------- | ------ | --------------------------------- | ----------- |
| ?      | ?               | ?      | ?                                 | ?           |

&uarr; [back to top](#top)

---
<a name="update-user"><a/>
## POST updateUser
### Description:
Updates user in database

### Request 
```
/User/UpdateUser
```

### Request body example
```
{
   ?
}
```


### Responses body example
```
{
   ?
}
```
---
### Parameter definition
| IN/OUT | Variable        | Type   | Example                           | Description |
| ------ | --------------- | ------ | --------------------------------- | ----------- |
| ?      | ?               | ?      | ?                                 | ?           |

&uarr; [back to top](#top)

---
<a name="get-user-courses"><a/>
## GET getUserCourses
### Description:
Displays all courses for a user

### Request 
```
/UserCourse/GetUserCourses
```

### Request body example
```
{
   ?
}
```


### Responses body example
```
{
   ?
}
```
---
### Parameter definition
| IN/OUT | Variable        | Type   | Example                           | Description |
| ------ | --------------- | ------ | --------------------------------- | ----------- |
| ?      | ?               | ?      | ?                                 | ?           |

&uarr; [back to top](#top)

---
<a name="get-user-course"><a/>
## GET getUserCourse
### Description:
Displays single course for a user

### Request 
```
/UserCourse/GetUserCourse
```

### Request body example
```
{
   ?
}
```


### Responses body example
```
{
   ?
}
```
---
### Parameter definition
| IN/OUT | Variable        | Type   | Example                           | Description |
| ------ | --------------- | ------ | --------------------------------- | ----------- |
| ?      | ?               | ?      | ?                                 | ?           |

&uarr; [back to top](#top)

---
<a name="add-user-course"><a/>
## POST addUserCourse
### Description:
Adds a course to a user in database

### Request 
```
/UserCourse/AddUserCourse
```

### Request body example
```
{
   ?
}
```


### Responses body example
```
{
   ?
}
```
---
### Parameter definition
| IN/OUT | Variable        | Type   | Example                           | Description |
| ------ | --------------- | ------ | --------------------------------- | ----------- |
| ?      | ?               | ?      | ?                                 | ?           |

&uarr; [back to top](#top)

---
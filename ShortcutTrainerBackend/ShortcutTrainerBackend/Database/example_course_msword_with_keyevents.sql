
--course info
 INSERT INTO public.course (id, title, "language", description, image_url, "subscription") VALUES(3, 'Microsoft Word', 'de-DE', 'Microsoft Word für Windows', 'word.jpg', 'free');

INSERT INTO public.course_tag (course_id, tag) VALUES(3, 'Word'); 


-- questions
INSERT INTO question (course_id, content) VALUES (3, 'Wie speichert man in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie kopiert man in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie fügt man in Microsoft Word ein?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie macht man in Microsoft Word rückgängig?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie schneidet man in Microsoft Word aus?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie druckt man in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie öffnet man in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie schließt man in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie sucht man in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie ersetzt man in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie erstellt man ein neues Dokument in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie markiert man Text fett in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie markiert man Text kursiv in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie unterstreicht man Text in Microsoft Word?');
INSERT INTO question (course_id, content) VALUES (3, 'Wie markiert man Text in Microsoft Word?');

-- answers
INSERT INTO answer (question_id, system, shortcut)
VALUES (1, 'Windows', '["ControlLeft", "KeyS"]'); -- Strg+S keycode = "ControlLeft" and "KeyS"
INSERT INTO answer (question_id, system, shortcut)
VALUES (2, 'Windows', '["ControlLeft", "KeyC"]'); -- Strg+C keycode = "ControlLeft" and "KeyC"
INSERT INTO answer (question_id, system, shortcut)
VALUES (3, 'Windows', '["ControlLeft", "KeyV"]'); -- Strg+V keycode = "ControlLeft" and "KeyV"
INSERT INTO answer (question_id, system, shortcut)
VALUES (4, 'Windows', '["ControlLeft", "KeyZ"]'); -- Strg+Z keycode = "ControlLeft" and "KeyZ"
INSERT INTO answer (question_id, system, shortcut)
VALUES (5, 'Windows', '["ControlLeft", "KeyX"]'); -- Strg+X keycode = "ControlLeft" and "KeyX"
INSERT INTO answer (question_id, system, shortcut)
VALUES (6, 'Windows', '["ControlLeft", "KeyP"]'); -- Strg+P keycode = "ControlLeft" and "KeyP"
INSERT INTO answer (question_id, system, shortcut)
VALUES (7, 'Windows', '["ControlLeft", "KeyO"]'); -- Strg+O keycode = "ControlLeft" and "KeyO"
INSERT INTO answer (question_id, system, shortcut)
VALUES (8, 'Windows', '["ControlLeft", "KeyW"]'); -- Strg+W keycode = "ControlLeft" and "KeyW"
INSERT INTO answer (question_id, system, shortcut)
VALUES (9, 'Windows', '["ControlLeft", "KeyF"]'); -- Strg+F keycode = "ControlLeft" and "KeyF"
INSERT INTO answer (question_id, system, shortcut)
VALUES (10, 'Windows', '["ControlLeft", "KeyH"]'); -- Strg+H keycode = "ControlLeft" and "KeyH"
INSERT INTO answer (question_id, system, shortcut)
VALUES (11, 'Windows', '["ControlLeft", "KeyN"]'); -- Strg+N keycode = "ControlLeft" and "KeyN"
INSERT INTO answer (question_id, system, shortcut)
VALUES (12, 'Windows', '["ControlLeft", "KeyB"]'); -- Strg+B keycode = "ControlLeft" and "KeyB"
INSERT INTO answer (question_id, system, shortcut)
VALUES (13, 'Windows', '["ControlLeft", "KeyI"]'); -- Strg+I keycode = "ControlLeft" and "KeyI"
INSERT INTO answer (question_id, system, shortcut)
VALUES (14, 'Windows', '["ControlLeft", "KeyU"]'); -- Strg+U keycode = "ControlLeft" and "KeyU"
INSERT INTO answer (question_id, system, shortcut)
VALUES (15, 'Windows', '["ShiftLeft", "ArrowLeft"]'); -- Shift+Pfeil keycode = "ShiftLeft" and "ArrowLeft"

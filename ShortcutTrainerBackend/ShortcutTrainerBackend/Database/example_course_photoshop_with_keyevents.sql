--course info for ps
INSERT INTO public.course (id, title, "language", description, image_url, "subscription") VALUES(4, 'Adobe Photoshop', 'de-DE', 'Adobe Photoshop für Bildbearbeitung', 'photoshop.jpg', 'free');

INSERT INTO public.course_tag (course_id, tag) VALUES(4, 'Photoshop');

-- ps questions
INSERT INTO question (course_id, content) VALUES (4, 'Wie öffnet man ein neues Dokument in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie speichert man in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie macht man in Photoshop rückgängig?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie schließt man in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie zoomt man in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie erstellt man eine neue Ebene in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie kopiert man in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie fügt man in Photoshop ein?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie dreht man in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie ändert man die Pinselgröße in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie verwendet man den Abwedler in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie verwendet man den Nachbelichter in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie verwischt man in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie ändert man die Deckkraft in Photoshop?');
INSERT INTO question (course_id, content) VALUES (4, 'Wie löscht man in Photoshop?');

-- ps answers
INSERT INTO answer (question_id, system, shortcut)
VALUES (16, 'Windows', '["ControlLeft", "N"]'); -- Strg+N keycode = "ControlLeft" and "N"
INSERT INTO answer (question_id, system, shortcut)
VALUES (17, 'Windows', '["ControlLeft", "S"]'); -- Strg+S keycode = "ControlLeft" and "S"
INSERT INTO answer (question_id, system, shortcut)
VALUES (18, 'Windows', '["ControlLeft", "Z"]'); -- Strg+Z keycode = "ControlLeft" and "Z"
INSERT INTO answer (question_id, system, shortcut)
VALUES (19, 'Windows', '["ControlLeft", "ShiftLeft", "N"]'); -- Strg+Shift+N keycode = "ControlLeft", "ShiftLeft", and "N"
INSERT INTO answer (question_id, system, shortcut)
VALUES (20, 'Windows', '["ControlLeft", "R"]'); -- Strg+R keycode = "ControlLeft" and "R"
INSERT INTO answer (question_id, system, shortcut)
VALUES (21, 'Windows', '["AltLeft", "RightArrow"]'); -- Alt+RightArrow keycode = "AltLeft" and "RightArrow"
INSERT INTO answer (question_id, system, shortcut)
VALUES (22, 'Windows', '["ShiftLeft", "O"]'); -- Shift+O keycode = "ShiftLeft" and "O"
INSERT INTO answer (question_id, system, shortcut)
VALUES (23, 'Windows', '["ShiftLeft", "B"]'); -- Shift+B keycode = "ShiftLeft" and "B"
INSERT INTO answer (question_id, system, shortcut)
VALUES (24, 'Windows', '["ShiftLeft", "E"]'); -- Shift+E keycode = "ShiftLeft" and "E"
INSERT INTO answer (question_id, system, shortcut)
VALUES (25, 'Windows', '["ShiftLeft", "X"]'); -- Shift+X keycode = "ShiftLeft" and "X"

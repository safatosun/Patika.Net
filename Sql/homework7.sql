CREATE TABLE employee (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50),
    birthday DATE,
    email VARCHAR(100)
);

UPDATE employee
SET name = 'Updated Name'
WHERE name LIKE 'K%' AND id BETWEEN 10 AND 20;

DELETE FROM employee
WHERE birthday BETWEEN '1988-02-02' AND '2010-06-06' AND name LIKE 'A%'
RETURNING *;

DELETE FROM employee
WHERE name LIKE '%z' AND name LIKE 'd%' AND id BETWEEN 20 AND 70
RETURNING *;

DELETE FROM employee
WHERE (email LIKE '%m' OR email LIKE 's%') AND birthday > '2010-02-02'
RETURNING *;

DELETE FROM employee
WHERE id > 36
RETURNING *;

DELETE FROM employee
WHERE email LIKE '%g'
RETURNING *;

INSERT INTO employee (id, name, birthday, email) VALUES 
(1, 'John Smith', '1/16/1985', 'john.smith1@squarespace.com'),
(2, 'Alice Johnson', '5/5/1994', 'alice.johnson2@latimes.com'),
(3, 'Michael Davis', '6/27/2005', 'michael.davis3@dagondesign.com'),
(4, 'Emily Brown', '5/9/1991', 'emily.brown4@goo.ne.jp'),
(5, 'Daniel Miller', '4/2/1999', 'daniel.miller5@chicagotribune.com'),
(6, 'Olivia Taylor', '10/29/1997', 'olivia.taylor6@thetimes.co.uk'),
(7, 'Matthew Wilson', '6/20/2005', 'matthew.wilson7@sbwire.com'),
(8, 'Sophia Clark', '4/18/1998', 'sophia.clark8@mail.ru'),
(9, 'Liam Johnson', '4/2/2002', 'liam.johnson9@usnews.com'),
(10, 'Emma White', '2/12/1994', 'emma.white10@reddit.com'),
(11, 'Aiden Wilson', '6/22/2009', 'aiden.wilson11@google.ru'),
(12, 'Oliver Martin', '12/17/1991', 'oliver.martin12@sohu.com'),
(13, 'Evelyn Garcia', '1/30/1990', 'evelyn.garcia13@uol.com.br'),
(14, 'Mia Martinez', '9/28/2002', 'mia.martinez14@flavors.me'),
(15, 'Charlotte Hall', '4/26/1986', 'charlotte.hall15@arstechnica.com'),
(16, 'Liam Baker', '8/11/2001', 'liam.baker16@soundcloud.com'),
(17, 'Sophia Lewis', '11/11/1994', 'sophia.lewis17@merriam-webster.com'),
(18, 'Ethan Walker', '3/25/1999', 'ethan.walker18@blogger.com'),
(19, 'Amelia Harris', '8/31/1999', 'amelia.harris19@csmonitor.com'),
(20, 'Mason Taylor', '5/30/2004', 'mason.taylor20@topsy.com'),
(21, 'Logan Anderson', '9/28/1988', 'logan.anderson21@joomla.org'),
(22, 'Grace Brown', '3/28/1989', 'grace.brown22@auda.org.au'),
(23, 'Chloe Clark', '1/10/2007', 'chloe.clark23@mapquest.com'),
(24, 'Dylan Davis', '5/2/1995', 'dylan.davis24@ox.ac.uk'),
(25, 'Madison Edwards', '12/30/1993', 'madison.edwards25@chronoengine.com'),
(26, 'Jackson Evans', '1/31/1996', 'jackson.evans26@squidoo.com'),
(27, 'Ava Smith', '1/7/1994', 'ava.smith27@eventbrite.com'),
(28, 'Aiden Taylor', '12/9/2000', 'aiden.taylor28@sciencedirect.com'),
(29, 'Ella Baldam', '8/8/2000', 'ella.baldam29@apache.org'),
(30, 'Mason Pert', '9/20/2005', 'mason.pert30@amazon.co.jp'),
(31, 'Liam Fullager', '7/23/1994', 'liam.fullager31@parallels.com'),
(32, 'Emma Prattin', '8/31/2001', 'emma.prattin32@typepad.com'),
(33, 'Oliver Simononsky', '12/8/2009', 'oliver.simononsky33@bing.com'),
(34, 'Sophia Aldrich', '6/10/1988', 'sophia.aldrich34@webnode.com'),
(35, 'Ethan Oswick', '3/5/2006', 'ethan.oswick35@flickr.com'),
(36, 'Ava Ambresin', '2/3/2007', 'ava.ambresin36@squidoo.com'),
(37, 'Mia Southern', '5/19/1995', 'mia.southern37@yandex.ru'),
(38, 'Jackson MacKniely', '11/19/2006', 'jackson.mackniely38@berkeley.edu'),
(39, 'Olivia Couroy', '12/30/1987', 'olivia.couroy39@nba.com'),
(40, 'Liam Zanre', '10/10/1996', 'liam.zanre40@tumblr.com'),
(41, 'Ella Spragg', '10/30/1986', 'ella.spragg41@google.fr'),
(42, 'Jackson Frift', '3/28/1992', 'jackson.frift42@mapquest.com'),
(43, 'Chloe Danelut', '3/7/1988', 'chloe.danelut43@cdbaby.com'),
(44, 'Logan Heathcoat', '11/12/2005', 'logan.heathcoat44@myspace.com'),
(45, 'Ella Yesichev', '2/11/1987', 'ella.yesichev45@guardian.co.uk'),
(46, 'Mia Van Halle', '10/20/2002', 'mia.vanhalle46@eepurl.com'),
(47, 'Jackson Smalecombe', '8/7/1988', 'jackson.smalecombe47@sciencedirect.com'),
(48, 'Ava Rastrick', '3/22/2006', 'ava.rastrick48@china.com.cn'),
(49, 'Ethan Urlin', '1/17/2006', 'ethan.urlin49@weebly.com'),
(50, 'Olivia Allsworth', '1/13/1994', 'olivia.allsworth50@china.com.cn');
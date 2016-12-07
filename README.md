
# ChatProject
Final Project in Advanced C# course (JB)



פרויקט ADO.NET  - חובת הגשה - ללא ציון

סוג הפרויקט:  Class Libraries Windows Forms
הדרישה: המשך לפרויקט צ'ט – שימוש בבסיס נתונים

ידע נדרש:
ADO.NET
חלוקה לשכבות
ידע ממודולים קודמים
 
 יש לבצע שדרוג לפרויקט הצ'ט שביצעתם במודול הקודם.

שינוי שמשפיע גם על צד הלקוח וגם על צד השרת:
1. יש לאפשר אך ורק למשתמשים רשומים להשתמש בשירות. ניתן לרשום משתמש דרך מערכת ה Client, וניתן בנפרד להתחבר עם שם משתמש קיים דרך מערכת ה-client. רישום והתחברות הן שתי פעולות שונות.
שדות משתמש :
ID
User name		
Last connection date
Is Connected
 
שינויים שמשפיעים רק על צד השרת:
2. את כל ההודעות אשר נשלחות במערכת יש לשמור ב DB בתבנית הבאה :
ID
Message Text
UserID
Sent date
Recipient id (למקרה של שליחת הודעה פרטית) – אתגר

3. יש לייצר מסכים עבור הServer המאפשרים חיפוש של הודעות על פי מילת חיפוש  או תאריך.
4. יש לאפשר חיפוש משתמשים על פי ID  או UserName
5. יש לאפשר מחיקה של משתמש.

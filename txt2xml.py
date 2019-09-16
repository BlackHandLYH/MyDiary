
f = open('diary.txt', 'r', encoding='utf-8')
lines = f.readlines()

for line in lines:
    things = line.split('\t')
    for thing in things:
        if "" in things:
            things.remove('')
    Date = things[0]
    Time = things[1]
    Weekday = things[2]
    Emotion = things[3]
    Color = things[4][1:]
    Diary = things[5][:-1]
    # print(Date)
    # print(Time)
    # print(Weekday)
    # print(Emotion)
    # print(Color)
    # print(Diary)
    xmline = '<Record Emotion="'
    xmline += Emotion
    xmline += '" Color="'
    xmline += Color
    xmline += '" Date="'
    xmline += Date
    xmline += '" Time="'
    xmline += Time
    xmline += '" Weekday="'
    xmline += Weekday
    xmline += '" Diary="'
    xmline += Diary
    xmline += '" />'
    print(xmline)
file = open("Eng_Code.txt", 'r')
data = file.read()
outf = open("Eng_Coords.txt", 'w')

x=1
y=1

outf.write('{')
for i in data:
    if i == '1':
        outf.write("{")
        outf.write('{0}, {1}'.format(x, y))
        outf.write("},")
    if i == '1' or i == '0':
        x+=1
        if x > 80:
            x = 1
            y+=1
outf.write('}')

outf.close()
outf = open("Eng_Coords.txt", 'r+')
outdata = outf.read()


count = -1
for i in outdata:
    if i == "}":
        count +=1
outf.write(str(count))

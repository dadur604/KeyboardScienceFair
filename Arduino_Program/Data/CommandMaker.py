from random import choice
in_file = 'Eng_Code.txt'
out_file = 'Eng_Comm.txt'

inf = open(in_file, 'r')
outf = open(out_file, 'a')
#randp = ''

#for i in range(1920):
#    randp = randp + str(choice([0, 1]))

#inf.write(randp)

data = inf.read()
i_b = 'a'
row = 1
count =  0
for i in data:
    if count == 0:
        outf.write('if (row == ' +str(row)+'){\n')
        row += 1
        count += 1
    elif count > 80:
        outf.write('}\n')
        count = 0
        continue
    elif i == i_b:
        outf.write('\tpulse();\n')
        count += 1
    elif i == '1':
        outf.write('\tdigitalWrite(din, HIGH);\n\tpulse();\n')
        i_b = i
        count += 1
    elif i == '0':
        outf.write('\tdigitalWrite(din, LOW);\n\tpulse();\n')
        i_b = i
        count += 1

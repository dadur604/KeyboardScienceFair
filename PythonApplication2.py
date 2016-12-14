import ctypes
import time
i=1
import wmi


#Get Current TID

while i==1:

    h = (ctypes.windll.user32.GetForegroundWindow())
#    print(h)
    tid = (ctypes.windll.user32.GetWindowThreadProcessId(h, "x"))
#    print (tid)

#Set var 'layout' to the keyboard layout of thread #1344 (windows explorer)
    layout=ctypes.windll.user32.GetKeyboardLayout(tid)
    print(layout)
    if layout==-255851511:
        print('English Colemak')
    else:
        if layout==67699721:
            print('English Querty')
        else:
            if layout==-266009557:
                print('Armenian')
            else:
                print('Unknown')
    time.sleep(2)
#   i += 1


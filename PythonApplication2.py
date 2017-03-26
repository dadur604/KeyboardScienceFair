import ctypes
import time
import serial
import sys
import threading
import pyautogui

ser = serial.Serial('com3', 9600)  # timeout = 1
# Get Current TID


def SendSerial():
    layout = ctypes.windll.user32.GetKeyboardLayout(0)
    while True:

        w_handle = (ctypes.windll.user32.GetForegroundWindow())
    #    print(h)
        w_tid = (ctypes.windll.user32.GetWindowThreadProcessId(w_handle, "x"))
    #    print (tid)

        layout_b = layout
        layout = ctypes.windll.user32.GetKeyboardLayout(w_tid)
        # print(layout)
        if layout != layout_b:
        #if layout == -255851511:
            #print('English Colemak')
            #ser.write(b'2')
            if layout == 67699721:
                print('English Querty')
                ser.write(b'1')
            elif layout == -266009557:
                print('Armenian')
                ser.write(b'2')
            else:
                print('Unknown')
                ser.write(b'1')
        #time.sleep(1)


def RecieveSerial():
    while True:
        inserial = ser.read()
        if inserial == b'1':
            pyautogui.keyDown('e')
        elif inserial == b'2':
            pyautogui.keyDown('n')
        elif inserial == b'3':
            pyautogui.keyUp('e')
        elif inserial == b'4':
            pyautogui.keyUp('n')


def Setup():
    layout = ctypes.windll.user32.GetKeyboardLayout(0)

    w_handle = (ctypes.windll.user32.GetForegroundWindow())
    #    print(h)
    w_tid = (ctypes.windll.user32.GetWindowThreadProcessId(w_handle, "x"))
    #    print (tid)

    layout = ctypes.windll.user32.GetKeyboardLayout(w_tid)
    # print(layout)
    if layout == -255851511:
        print('English Colemak')
        ser.write(b'1')
    elif layout == 67699721:
        print('English Querty')
        ser.write(b'1')
    elif layout == -266009557:
        print('Armenian')
        ser.write(b'2')
    else:
        print('Unknown')
        ser.write(b'1')


Setup()
p1 = threading.Thread(target=SendSerial)
p2 = threading.Thread(target=RecieveSerial)
p1.start()
p2.start()

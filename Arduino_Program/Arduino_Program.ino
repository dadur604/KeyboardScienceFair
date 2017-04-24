int led = 11;
int flm = 10;
int lp = 4;
int scp = 9;
int din = 8;
int sw1 = 2;
int sw2 = 3;

int current = '1';

void pulse() {
  digitalWrite(scp, LOW);
  digitalWrite(scp, HIGH);
}

void setup() {
	Serial.begin(9600);
	pinMode(led, OUTPUT);
	pinMode(flm, OUTPUT);
	pinMode(lp, OUTPUT);
	pinMode(scp, OUTPUT);
	pinMode(din, OUTPUT);

	pinMode(sw1, INPUT_PULLUP);
	pinMode(sw2, INPUT_PULLUP);

	analogWrite(led, 10);
	digitalWrite(scp, HIGH);
	digitalWrite(din, LOW);
	digitalWrite(flm, LOW);
	digitalWrite(lp, LOW);

	cli();
	  TCCR1A = 0;
	  TCCR1B = 0;
	  TCNT1  = 0;
	  OCR1A = 3000;// = (16*10^6) / (1*1024) - 1 (must be <65536)
	  TCCR1B |= (1 << WGM12);
	  TCCR1B |= (0 << CS12) | (1 << CS11) | (0 << CS10);
	  TIMSK1 |= (1 << OCIE1A);
	sei();
}

int y = 1;
int x = 1;
int row = 1;
ISR(TIMER1_COMPA_vect){
	//@#
	//Insert Language Codes Here
	//@#
  row++;
  if (row > 24) {
    row = 1;
  }
}

int sw1s = 0;
int sw2s = 0;
int first1 = 1;
int first2 = 2;
void loop() {
	  // put your main code here, to run repeatedly:

	if (Serial.available() > 0) {
					// read the incoming byte:
					current = Serial.read(),DEC;
					//Serial.write(current);
	}

	if (digitalRead(sw1) == HIGH){
	  if (first1 == 1){
		  Serial.write('3');
		  first1 = 0;
		}
		sw1s = 0;
	}
	if (digitalRead(sw2) == HIGH){
		if (first2 == 1){
		  Serial.write('4');
		  first2 = 0;
		}
		sw2s = 0;
	}
	if (digitalRead(sw1) == LOW){
		if (sw1s == 0){
			Serial.write('1');
			sw1s = 1;
			first1 = 1;
		}
	}
	if (digitalRead(sw2) == LOW){
		if (sw2s == 0){
			Serial.write('2');
			sw2s = 1;
			first2 = 1;
		}
	}
}
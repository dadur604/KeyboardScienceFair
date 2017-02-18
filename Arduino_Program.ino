int led = 11;
int flm = 10;
int lp = 4; 
int scp = 9;
int din = 8;


void pulse() {
  digitalWrite(scp, LOW);
  digitalWrite(scp, HIGH);
}


void setup() {
  // put your setup code here, to run once:
pinMode(led, OUTPUT);
pinMode(flm, OUTPUT);
pinMode(lp, OUTPUT);
pinMode(scp, OUTPUT);
pinMode(din, OUTPUT);


  
  //set pins as outputs
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(13, OUTPUT);

analogWrite(led, 10);
digitalWrite(scp, HIGH);
digitalWrite(din, LOW);
digitalWrite(flm, LOW);
digitalWrite(lp, LOW);

cli();//stop interrupts

//set timer1 interrupt at 1Hz
  TCCR1A = 0;// set entire TCCR1A register to 0
  TCCR1B = 0;// same for TCCR1B
  TCNT1  = 0;//initialize counter value to 0
  // set compare match register for 1hz increments
  OCR1A = 319;// = (16*10^6) / (1*1024) - 1 (must be <65536)
  // turn on CTC mode
  TCCR1B |= (1 << WGM12);
  // Set CS10 and CS12 bits for 1024 prescaler
  TCCR1B |= (0 << CS12) | (0 << CS11) | (1 << CS10);
  // enable timer compare interrupt
  TIMSK1 |= (1 << OCIE1A);

sei();//allow interrupts

}//end setup
int row = 1;
ISR(TIMER1_COMPA_vect){//timer1 interrupt 1Hz toggles pin 13 (LED)
//generates pulse wave of frequency 1Hz/2 = 0.5kHz (takes two cycles for full wave- toggle high then toggle low)
if (row == 1){
digitalWrite(flm, HIGH);
}
if ( row  < 11 || row > 14) {
digitalWrite(din, HIGH);
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
digitalWrite(din, LOW);
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();

digitalWrite(din, HIGH);
pulse();
pulse();
pulse();
pulse();
pulse();

digitalWrite(din, HIGH);
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
}
else if (row > 10 && row < 15) {
  digitalWrite(din, HIGH);
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();

digitalWrite(din, LOW);
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();

digitalWrite(din, HIGH);
pulse();
pulse();
pulse();
pulse();
pulse();

digitalWrite(din, LOW);
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();
pulse();

}

digitalWrite(lp, HIGH);
digitalWrite(lp, LOW);

digitalWrite(flm, LOW);

row++;
if (row > 24){
  row = 1;
}
}





void loop() {
  // put your main code here, to run repeatedly:



//delay(1);

}

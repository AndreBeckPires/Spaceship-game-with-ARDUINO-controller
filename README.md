# Spaceship-game-with-ARDUINO-controller
A simple spaceship  game controlled with Arduino


This is the ARDUINO code:

int rotation=0;         


void setup() {
  Serial.begin(9600);       
  pinMode(A0,INPUT);       
  pinMode(13, INPUT_PULLUP); 
}

void loop() {
  rotation = analogRead(A0);
 



  Serial.print(map(rotation,0,1023,200,400));
  Serial.println();
  delay(40); 
  if (digitalRead(13) == LOW) { 
  Serial.print("1");
  Serial.print(",");
  
 }
 else{
  Serial.print("0");
  Serial.print(",");
  
  
}
}


int LED = 2;
int BUTTON = 3;


void setup()
{
  Serial.begin(9600);
  
  pinMode(LED,OUTPUT);
  pinMode(BUTTON,INPUT);

 // pinMode(A0, INPUT);
}

void loop()
{
 // int sensorValue = analogRead(A0);
  //Serial.println(sensorValue);
  //delay(1);
  
  if(digitalRead(BUTTON) == HIGH)
  { 
    digitalWrite(LED,HIGH);
    Serial.write(1);
    Serial.flush();
    delay(20);   
  }
  else
  {   
    digitalWrite(LED,LOW);
  }
  
}

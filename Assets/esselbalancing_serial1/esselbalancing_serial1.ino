#include <AccelStepper.h>
#include <SPI.h>
#include <Pixy.h>
#include <SoftwareSerial.h>
AccelStepper stepper1(1, 8, 9);
SoftwareSerial portOne(11, 12);
Pixy pixy;

int Am0 = 28;
int Am1 = 30;
int Am2 = 32;
int Am3 = 34;
int Am4 = 36;
int Am5 = 38;
int Bm0 = 40;
int Bm1 = 42;
int Bm2 = 44;
int Bm3 = 46;
int Bm4 = 48;
int Bm5 = 3;

int AtMa= 4;
int start=6;
int Shome=5;
int light=10;
int ms1=18;
int ms2=17;
int ms3=16;

byte canalA = 0;
byte canalB = 0;
int  Enablepin1 = 7;
boolean AmS0, AmS1, AmS2, AmS3, AmS4, AmS5;
boolean BmS0, BmS1, BmS2, BmS3, BmS4, BmS5;
boolean AtMaS,starts,Shomes;
boolean stringComplete = false;
boolean wait=false;
boolean wait2=false;
char out[4];
int Pbufer[10];
int bloques=0;
int i=0;
char opcion;


void setup() {
  Serial.begin(9600);
  portOne.begin(9600);
  pinMode(Enablepin1, OUTPUT);
  pinMode(Am0, INPUT);
  pinMode(Am1, INPUT);
  pinMode(Am2, INPUT);
  pinMode(Am3, INPUT);
  pinMode(Am4, INPUT);
  pinMode(Am5, INPUT);
  pinMode(Bm0, INPUT);
  pinMode(Bm1, INPUT);
  pinMode(Bm2, INPUT);
  pinMode(Bm3, INPUT);
  pinMode(Bm4, INPUT);
  pinMode(Bm5, INPUT);
  pinMode(AtMa,INPUT);
  pinMode(Shome,INPUT);
  pinMode(start,INPUT);
  pinMode(light,OUTPUT);
  pinMode(Enablepin1,OUTPUT);
  pinMode(ms1,OUTPUT);
  pinMode(ms2,OUTPUT);
  pinMode(ms3,OUTPUT);
  digitalWrite(Enablepin1,LOW);
  
  digitalWrite(ms1,HIGH);
  digitalWrite(ms2,HIGH);
  digitalWrite(ms3,LOW);
  stepper1.setMaxSpeed(600.0);
  stepper1.setAcceleration(10000.0);
  stepper1.setPinsInverted(false, false, false);
  stepper1.setSpeed(600);
  stepper1.setCurrentPosition(0);
  //stepper1.runToNewPosition(0);
  pixy.init();
  delay(2000);
  Serial2.println("al ataquer");
  readinput();
}

void loop() {
   readinput();
   delay(10);
   //Serial.print(signal(start)); Serial.print("   ");
   //Serial.println(signal(Shome));
  if(canalA>0 && canalB>0){
    if (!AtMaS){//manual
    if(!wait){subPixy();
            digitalWrite(light,HIGH);
             wait=true;
            } 
    //Serial.println("manual!!!!");
    if(signal(start)){//Serial.println("a calcular");
      calculo(out);
      digitalWrite(light,LOW);
      for (int a = 0; a < 4; a++) {
        Serial.print(out[a], DEC); Serial.print(";");
      }
      Serial.println();
      delay(2000);
      }
    if (signal(Shome)){
      //Serial.println("home!!!!");
      motor('H');
      digitalWrite(light,LOW);
      delay(2000);
      wait=false;
    }
  //calculo(out);
} else{                                  //automatico
       if(!wait2){subPixy();
            digitalWrite(light,HIGH);
             wait2=true;
           } 
        for (int b = 0; b < 4; b++) {
          Serial.print(out[b],DEC); Serial.print(","); //lo cambie
        }
        Serial.println(); //lo cambie
        delay(2000);
        portOne.listen(); // no pude
        i=0;
        while (Serial.available() > 0) {
        Pbufer[i] = Serial.read();
        i++;
        Serial.write(Pbufer[i]); // lo cambie
        }
        //if((Pbufer[1]==0x01) && (Pbufer[3]==0x01)){ //mensaje correcto
        if(Pbufer[0]=='A'){
        opcion=Pbufer[1];
        Serial.println(opcion);
        stringComplete = true;
        }
        if(stringComplete){
         switch (opcion){
         case 'L':motor('L');break;
         case 'R':motor('R');break;
         default: motor('H');
                  digitalWrite(light,LOW);
                  wait2=false;
                  delay(2000);
                  break; 
         }
         stringComplete=false;
         for (int bux=0;bux<10;bux++){
           Pbufer[bux]=0;
           }
        }
  }
  }else {motor('H');}


}


void readinput() {
  bloques=0;
  AmS0 = digitalRead(Am0); if (AmS0) {
    bitWrite(canalA, 0, 1);
  } else {
    bitWrite( canalA, 0, 0);
  }
  AmS1 = digitalRead(Am1); if (AmS1) {
    bitWrite(canalA, 1, 1);
  } else {
    bitWrite( canalA, 1, 0);
  }
  AmS2 = digitalRead(Am2); if (AmS2) {
    bitWrite(canalA, 2, 1);
  } else {
    bitWrite( canalA, 2, 0);
  }
  AmS3 = digitalRead(Am3); if (AmS3) {
    bitWrite(canalA, 3, 1);
  } else {
    bitWrite( canalA, 3, 0);
  }
  AmS4 = digitalRead(Am4); if (AmS4) {
    bitWrite(canalA, 4, 1);
  } else {
    bitWrite( canalA, 4, 0);
  }
  AmS5 = digitalRead(Am5); if (AmS5) {
    bitWrite(canalA, 5, 1);
  } else {
    bitWrite( canalA, 5, 0);
  }

  BmS0 = digitalRead(Bm0); if (BmS0) {
    bitWrite(canalB, 0, 1);
  } else {
    bitWrite( canalB, 0, 0);
  }
  BmS1 = digitalRead(Bm1); if (BmS1) {
    bitWrite(canalB, 1, 1);
  } else {
    bitWrite( canalB, 1, 0);
  }
  BmS2 = digitalRead(Bm2); if (BmS2) {
    bitWrite(canalB, 2, 1);
  } else {
    bitWrite( canalB, 2, 0);
  }
  BmS3 = digitalRead(Bm3); if (BmS3) {
    bitWrite(canalB, 3, 1);
  } else {
    bitWrite( canalB, 3, 0);
  }
  BmS4 = digitalRead(Bm4); if (BmS4) {
    bitWrite(canalB, 4, 1);
  } else {
    bitWrite( canalB, 4, 0);
  }
  BmS5 = digitalRead(Bm5); if (BmS5) {
    bitWrite(canalB, 5, 1);
  } else {
    bitWrite( canalB, 5, 0);
  }
  
  AtMaS=digitalRead(AtMa);
  starts=digitalRead(start);
  Shomes=digitalRead(Shome);
  
  for(int bux=0;bux<8;bux++){
    if(bitRead(canalA,bux)){bloques++;}
    if(bitRead(canalB,bux)){bloques++;}
    }
   
  switch(canalA){
   case 1: out[1]=1;break;
    case 2: out[1]=2;break;
     case 4: out[1]=3;break;
      case 8: out[1]=4;break;
       case 16: out[1]=5;break;
        case 32: out[1]=6;break;
         default: out[1]=0;break;
    }
  switch(canalB){
   case 1: out[3]=1;break;
    case 2: out[3]=2;break;
     case 4: out[3]=3;break;
      case 8: out[3]=4;break;
       case 16: out[3]=5;break;
        case 32: out[3]=6;break;
         default: out[3]=0;break;
    }
  
}

void subPixy()
{
  static int i = 0;
  int j;
  uint16_t blocks;
  char buf[32];
  int aux1 = 0, aux2 = 0;
  cli();
  while (blocks<bloques){   
      blocks = pixy.getBlocks();
      }
  sei();    
     if (blocks>0) {
       //i++;
       //if (i%50==0){
      //sprintf(buf, "Detected %d:\n", blocks);
      //Serial.print(buf);
      for (j = 0; j < blocks; j++)
      {
        //sprintf(buf, "  block %d: ", j);
        //Serial.print(buf);
        //pixy.blocks[j].print();
        int xp = pixy.blocks[j].x;
        int signature = pixy.blocks[j].signature;
        if (xp < 150) { //canal A
          aux1 = signature;
          }
        else if (xp > 150) { //canal B
          aux2 = signature;
          
          }
      }
   // }
    }
  //Serial.print("aux1 ");Serial.println(aux1);
  //Serial.print("aux2 ");Serial.println(aux2);
  
    
    switch (aux1) {
    case 1: //amarillo
      out[0] = 'A';
      break;
    case 2: //rojo
      out[0] = 'R';
      break;
    case 3: //verde
      out[0] = 'V';
      break;
   default:
      out[0]=0;
      break;
  }

  switch (aux2) {
    case 1: //amarillo
      out[2] = 'A';
      break;
    case 2: //rojo
      out[2] = 'R';
      break;
    case 3: //verde
      out[2] = 'V';
      break;
    default:
      out[2]=0;
      break;
  }
 }
  

void calculo(char salida[]){
  //f=Distancia x peso
  long fuerza1,fuerza2;
  int peso1,peso2,distancia1,distancia2;
  switch (salida[0]){
    case 'A':peso1=1;break;
    case 'R':peso1=2;break;
    case 'V':peso1=3;break;
    default:peso1=0;break;
  }
  switch (salida[2]){
    case 'A':peso2=1;break;
    case 'R':peso2=2;break;
    case 'V':peso2=3;break;
    default: peso2=0;break;
  }
 distancia1=salida[1];
 distancia2=salida[3];
 fuerza1=distancia1*peso1;
 fuerza2=distancia2*peso2;
 //Serial.print("F1 "); Serial.println(fuerza1);
 //Serial.print("F2 "); Serial.println(fuerza2);
 if(fuerza1<fuerza2){motor('R');}
 else if (fuerza1>fuerza2){motor('L');}
 else {motor('H');}
 
  
  
}


void motor(char str){
  long pos=stepper1.currentPosition();
  //Serial.println(pos);
  switch (str){
   case 'H':     digitalWrite(ms1,LOW);
                 digitalWrite(ms2,HIGH);
                 digitalWrite(ms3,LOW);
                 if (pos>0){
                 do{
                 pos-=5;
                 stepper1.runToNewPosition(pos);
                 //Serial.println(pos);
                 //delay(1);
                 }while(pos>0);}
                 else if (pos<0){
                   do{
                 pos+=5;
                 stepper1.runToNewPosition(pos);
                 //Serial.println(pos);
                 //delay(1);
                 }while(pos<0);}
                 break;
                 
   case 'L':     digitalWrite(ms1,LOW);
                 digitalWrite(ms2,HIGH);
                 digitalWrite(ms3,LOW);
               do{
                 pos+=5;
                 stepper1.runToNewPosition(pos);
                 //Serial.println(pos);
                 //delay(1);
                 }while(pos<120);
                 break;
                 
   case 'R':   digitalWrite(ms1,LOW);
               digitalWrite(ms2,HIGH);
               digitalWrite(ms3,LOW);
               do{
               pos-=5;  
               stepper1.runToNewPosition(pos);
               //Serial.println(pos);
                 //delay(1);
                 }while(pos>-120);
                 break;              
     
}
}


boolean signal(int input) {
  boolean estado;
  int buttonState;
  buttonState = digitalRead(input);
  if (buttonState == HIGH) {
    delayMicroseconds(200);
    buttonState = digitalRead(input);
    if (buttonState == HIGH) {
      estado = true;
      return estado;
    }
  }
  else {
    estado = false;
    return estado;
  }
}


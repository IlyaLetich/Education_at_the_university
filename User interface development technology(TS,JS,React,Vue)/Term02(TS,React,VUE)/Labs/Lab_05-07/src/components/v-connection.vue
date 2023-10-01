<template>
  <div class = "vConnection" id="kontakt">
    <div class="container">
      <div class="div_01">
        <p class="p_01">Связь с нами</p>
        <p class="p_02">У вас остались вопросы? Напишите нам - мы ответим в ближайшее время!</p>
        <img class="imgC01" src="https://static.tildacdn.com/tild3139-6664-4962-a236-353430633664/noroot.png" alt=" " width="70" height="60"/>
        <p class="p_03">+7 (111) 222-33-44</p>
        <img class="imgC02" src="https://static.tildacdn.com/tild6134-6139-4263-b432-366661393632/mail.png" alt=" " width="47" height="47"/>
        <p class="p_04">order@bu-one.ru</p>
      </div>
      <div class="div_02">
        <p class="p_11">Имя</p> 
        <p class="p_12">Фамилия</p>
        <p></p>
        <input @input="checkValidName" id="N1" name="nameUser" class="inp_01" placeholder="Ivan"
          :style="{'border-bottom' : '1px solid rgba(255,' + isErrorName + ',' + isErrorName + ',' + 0.2 + ')'}"/>
        <img src="https://www.freeiconspng.com/uploads/error-icon-15.png" width="17" height="17" :style="{'opacity' : checkField_01}"/>
        <input @input="checkValidFamaly" id="N2" famaly="nameUser" class="inp_02" placeholder="Ivanovich"
          :style="{'border-bottom' : '1px solid rgba(255,' + isErrorFamaly + ',' + isErrorFamaly + ',' + 0.2 + ')'}"/>
        <img src="https://www.freeiconspng.com/uploads/error-icon-15.png" width="17" height="17" :style="{'opacity' : checkField_02}"/>
        <p class="p_13">Сообщение</p>
        <textarea class="inp_03" id="N3" placeholder="Privet mir!!!"/>
        <button class="boton" @click="send">Отправить сообщение</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "v-connection",
  props: {
    
  },
  data(){
    return{
      isErrorName: 255,
      isErrorFamaly: 255,
      checkField_01: 0,
      checkField_02: 0,
    }
  },
  methods: {
    checkValidName(){
      let text = document.getElementById('N1').value;
      let regexp = /[A-Z]{1}[a-z]{1,}/;
      if(!regexp.test(text)){
        this.checkField_01 = 1;
        this.isErrorName = 0;
        return false;
      }
      else{
        this.checkField_01 = 0;
        this.isErrorName = 255;
        return true;
      }
    },
    checkValidFamaly(){
      let text = document.getElementById('N2').value;
      let regexp = /[A-Z]{1}[a-z]{1,}/;
      if(!regexp.test(text)){
        this.checkField_02 = 1;
        this.isErrorFamaly = 0;
        return false;
      }
      else{
        this.checkField_02 = 0;
        this.isErrorFamaly = 255;
        return true;
      }
    },
    send(){
      if(this.checkValidFamaly() && this.checkValidName()){
        document.getElementById('N3').value = "";
        document.getElementById('N2').value = "";
        document.getElementById('N1').value = "";
      }
      else alert("Введите корректно данные");
    },
  }
}
</script>

<style>
  .vConnection{
    background-image: url("E:\\Vue\\lab05\\src\\assets\\Connection\\img1.png");
    height: 623px;
    width: 100%;
  }
  .container{
    display: grid;
    grid-template-columns: repeat(2, 1fr);
  }
  .div_01{
    grid-column: 1;
    margin-left: -320px;
    height: 350px;
    margin-top: 122px;
  }
  .div_02{
    grid-column: 2;
    margin-top: 135px;
    height: 350px;
  }
  .p_01{
    margin-left: 405px;
    width: 445px;
    height: 47px;
    font-family: 'Merriweather';
    font-style: normal;
    font-weight: 900;
    font-size: 48px;
    line-height: 69px;
    color: #FFFFFF;
  }
  .p_02{
    margin-top: 60px;
    margin-left: 405px;
    width: 445px;
    height: 43px;
    font-family: 'Lato';
    font-weight: lighter;
    font-style: normal;
    font-size: 18px;
    line-height: 25px;
    color: #FFFFFF;
  }
  .p_03{
    position: absolute;
    top: 4015px;
    left: 220px;
    display: inline;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 100;
    font-size: 21px;
    line-height: 29px;
    color: #FFFFFF;
  }
  .p_04{
    position: absolute;
    top: 4015px;
    left: 480px;
    display: inline;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 100;
    font-size: 21px;
    line-height: 29px;
    color: #FFFFFF;
  }
  .imgC01{
    position: absolute;
    left: 170px;
    top: 4000px;
  }
  .imgC02{
    position: absolute;
    left: 430px;
    top: 4007px;
  }
  img, svg{
    vertical-align: baseline;
  }
  .p_11{
    display: inline-block;
    width: 125px;
    height: 16px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 400;
    font-size: 16px;
    line-height: 22px;
    color: #FFFFFF;
  }
  .inp_03{
    background-color: rgb(0, 0, 0, 0);
    margin-top: 15px;
    width: 540px;
    height: 100px;
    border: 0;
    border-bottom: 1px solid rgba(255, 255, 255, 0.2);
    font-size: 24px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 100;
    color: #FFFFFF;
  }
  .p_13{
    display: block;
    width: 125px;
    margin-top: 30px;
    height: 16px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 400;
    font-size: 16px;
    line-height: 22px;
    color: #FFFFFF;
  }
  .p_12{
    display: inline-block;
    margin-left: 160px;
    width: 125px;
    height: 16px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 400;
    font-size: 16px;
    line-height: 22px;
    color: #FFFFFF;
  }
  input:focus,textarea:focus {
    outline: none;
    border-bottom: 1px solid white;
  }
  .inp_01{
    background-color: rgb(0, 0, 0, 0);
    margin-top: 5px;
    width: 255px;
    height: 40px;
    border: 0;
    border-bottom: 1px solid rgba(255, 255, 255, 0.2);
    font-size: 24px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 100;
    color: #FFFFFF;
  }
  .inp_02{
    background-color: rgb(0, 0, 0, 0);
    height: 40px;
    border: 0;
    width: 255px;
    border-bottom: 1px solid rgba(255, 255, 255, 0.2);
    margin-left: 15px;
    font-size: 24px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 100;
    color: #FFFFFF;
  }
  textarea{
    resize: none;
  }
  .boton{
    width: 270px;
    height: 60px;
    background: #005FA3;
    font-size: 16px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 100;
    color: #FFFFFF;
    margin-left: 270px;
    margin-top: 70px;
  }
  .boton:hover{
    background: #007fda;
  }
</style>
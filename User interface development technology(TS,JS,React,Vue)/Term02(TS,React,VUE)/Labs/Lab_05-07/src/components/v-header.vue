<template>
    <div :class="$style.header">
        <v_popup_service
            v-if="checkPopup"
            @click="closePopup">
            <iframe src="https://yandex.ru/map-widget/v1/?um=constructor%3Aadf499095e6430e798a9d08c9e9d8cfe8685fd542b83d163c032ed6888c79939&amp;source=constructor" width="598" height="568" frameborder="0"></iframe>
        </v_popup_service>
        <div :class="$style.img1h"></div>
        <div :class="$style.text1head">BuhOne</div>
        <div :class="$style.img1hed"></div>
        <div :class="$style.img2hed"></div>
        <div :class="$style.img3hed"></div>
        <div :class="$style.img4hed" @click="openPopup"></div>
        <a :class="$style.text_101" href="http://localhost:8080#carouselExampleCaptions">Главная</a>
        <a :class="$style.text_102" href="http://localhost:8080#roditel">Услуги</a>
        <a :class="$style.text_103" href="http://localhost:8080#kiesy">Кейсы</a>
        <a :class="$style.text_104" href="http://localhost:8080#slideerrman">О компании</a>
        <a :class="$style.text_105" href="http://localhost:8080#kontakt">контакты</a>
    </div>
</template>
  
<script>
import vServicePopup from './v-popum-service.vue'

export default {
    name: "v-header",
    components: {
        v_popup_service: vServicePopup,
    },
    props: {

    },
    
    data(){
        return{
            checkPopup: false,
        }
      },
    methods: {
        closePopup(){
            this.checkPopup = false;
        },
        openPopup(){
            this.checkPopup =true;
        }
    },
}

</script>

<style module>
    .img1hed{
        left: 523px;
        top: 24px;
        position: absolute;
        width: 160px;
        height: 30px;
        background-image: url("E:\\Vue\\lab05\\src\\assets\\img1.png");
    }
    .img2hed{
        left: 730px;
        top: 17px;
        position: absolute;
        width: 160px;
        height: 40px;
        background-image: url("E:\\Vue\\lab05\\src\\assets\\img2.png");
    }
    .img3hed{
        left: 950px;
        top: 21px;
        position: absolute;
        width: 160px;
        height: 40px;
        background-image: url("E:\\Vue\\lab05\\src\\assets\\img3.png");
    }
    .img4hed{
        left: 1150px;
        top: 24px;
        position: absolute;
        width: 150px;
        height: 30px;
        background-image: url("E:\\Vue\\lab05\\src\\assets\\img4.png");
        background-size: 147px;
    }
    .header{
        height: 110px;
        background-color: #f9f9f9;
    }
    .img1h{
        position: absolute;
        left: 194px;
        margin-top: 15px;
        width: 70px;
        height: 70px;
        background-image: url("E:\\Vue\\lab05\\src\\assets\\logo.png");
    }
    
    .text1head{
        position: absolute;
        left: 275px;
        top: 33px;

        font-family: 'Merriweather';
        font-style: normal;
        font-weight: 900;
        font-size: 36px;
        line-height: 50px;

        /* Accent */

        color: #005FA3;
    }
    .text_101{
        decoration: none;
        position: absolute;
        left: 530px;
        top: 62px;

        font-family: 'Lato';
        font-style: normal;
        font-weight: 700;
        font-size: 14px;
        line-height: 17px;
        letter-spacing: 0.1em;
        text-transform: uppercase;
        color: #222222;
    }
    .text_102{
        position: absolute;
        left: 700px;
        top: 62px;

        font-family: 'Lato';
        font-style: normal;
        font-weight: 700;
        font-size: 14px;
        line-height: 17px;
        letter-spacing: 0.1em;
        text-transform: uppercase;
        color: #222222;
    }
    .text_103{
        position: absolute;
        left: 850px;
        top: 62px;

        font-family: 'Lato';
        font-style: normal;
        font-weight: 700;
        font-size: 14px;
        line-height: 17px;
        letter-spacing: 0.1em;
        text-transform: uppercase;
        color: #222222;
    }
    .text_104{
        position: absolute;
        left: 990px;
        top: 62px;

        font-family: 'Lato';
        font-style: normal;
        font-weight: 700;
        font-size: 14px;
        line-height: 17px;
        letter-spacing: 0.1em;
        text-transform: uppercase;
        color: #222222;
    }
    .text_105{
        position: absolute;
        left: 1200px;
        top: 62px;

        font-family: 'Lato';
        font-style: normal;
        font-weight: 700;
        font-size: 14px;
        line-height: 17px;
        letter-spacing: 0.1em;
        text-transform: uppercase;
        color: #222222;
    }
</style>
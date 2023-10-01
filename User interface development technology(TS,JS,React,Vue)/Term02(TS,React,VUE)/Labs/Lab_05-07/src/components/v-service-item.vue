<template>
    <v_popup_service
        v-if="checkPopup"
        @click="closePopup">
        <div class="buttPopSer" :style="{'background' : 'linear-gradient(0deg, rgba(0, 0, 0, 0.65), rgba(0, 0, 0, 0.65)), url(' + require('E:/Vue/lab05/src/assets/Service/' + service_Data_Item.img1)}">
        </div>
        <div class="SerTextPop1">{{service_Data_Item.text1}}</div>
        <div class="SerTextPop1">{{service_Data_Item.text2}}</div>
    </v_popup_service>
    <div class="serviseItem" @click="openPopup">
        <div class="buttItemSer" :style="{'background' : 'linear-gradient(0deg, rgba(0, 0, 0, 0.65), rgba(0, 0, 0, 0.65)), url(' + require('E:/Vue/lab05/src/assets/Service/' + service_Data_Item.img1)}">
            <p class="SerText1">{{service_Data_Item.text1}}</p>
        </div>
    </div>
</template>
    
<script>
import vServicePopup from './v-popum-service.vue'

export default {
    name: "v-service-item",
    components: {
        v_popup_service: vServicePopup,
    },
    props: {
        service_Data_Item: {
            type: Object,
            default: () => null
        }
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
    
<style>
    .buttItemSer{
        width: 350px;
        height: 360px;
        background-color: black;
        margin-bottom: 20px;
    }
    .SerText1{
        padding-right: 305px;
        padding-left: 45px;
        padding-top: 261px;
        padding-bottom: 100px;
        width: 187px;
        height: 54px;
        font-family: 'Lato';
        font-style: normal;
        font-weight: 900;
        font-size: 24px;
        line-height: 30px;
        color: #FFFFFF;
    }
    .SerTextPop1{
        margin-top: 30px;
        margin-left: 130px;
        width: 187px;
        height: 54px;
        font-family: 'Lato';
        font-style: normal;
        font-weight: 900;
        font-size: 24px;
        line-height: 30px;
        color: black;
    }
    .SerText1:hover{
        background: linear-gradient(0deg, rgba(0, 95, 163, 0.65), rgba(0, 95, 163, 0.65));
    }
    .serviseItem{
        display: inline-block;
        margin-right: 30px;
    }
    .buttPopSer{
        margin-left: 130px;
        margin-top: 40px;
        width: 350px;
        height: 360px;
    }
</style>
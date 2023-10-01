<template>
  <div :class="$style.vCarouselItem_02">
      <div :class="$style.text1"> {{ item_data.text3 }}</div>
      <div :class="$style.avatar">
        <img :class="$style.imgMicro_02" :src="require('E:/Vue/lab05/src/assets/slider_02/' + item_data.img1)">
        <div :class="$style.chast2">
          <div :class="$style.d1">{{ item_data.text1 }}</div>
          <div :class="$style.d2">{{ item_data.text2 }}</div>
        </div>
      </div>      
  </div>
</template>

<script lang="ts">
export default {
  name: "v-carousel-item",
  props: {
    item_data: {
      type: Object,
      default: () => null
    }
  },
  data(){
    return{

    }
  }
}
</script>

<style module>
  .chast2{
    display: inline-block;
    margin-left: 35px;
  }
  .imgMicro_02{
    display: inline-block;
    margin-left: 75px;
  }
  .vCarouselItem_02{
    background-color: #EBEBEB;
    width: 1110px;
    height: 320px;
  }
  .text1{
    width: 920px;
    height: 92px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 300;
    font-size: 18px;
    line-height: 25px;
    color: #000000;
    margin-left: 75px;
    margin-right: 75px;
    margin-top: 40px;
  }
  .d1{
    display: inline-block;
    margin-top: 10px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 900;
    font-size: 18px;
    color: #000000;
    padding-bottom: 0px;
  }
  .d2{
    font-family: 'Lato';
    font-style: normal;
    font-weight: 400;
    font-size: 14px;
    line-height: 19px;
    color: #4F4F4F;
  }
  .avatar{
    margin-top: 70px;
  }
</style>
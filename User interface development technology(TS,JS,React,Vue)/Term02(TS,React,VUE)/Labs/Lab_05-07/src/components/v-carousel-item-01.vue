<template>
  <div class = "vCarouselItem">
      <img :class="$style.imgMicro" :src="require('E:/Vue/lab05/src/assets/slider_01/' + item_data.img1)">
      <img :class="$style.imgMicro" :src="require('E:/Vue/lab05/src/assets/slider_01/' + item_data.img2)">
      <img :class="$style.imgMicro" :src="require('E:/Vue/lab05/src/assets/slider_01/' + item_data.img3)">
      <img :class="$style.imgMicro" :src="require('E:/Vue/lab05/src/assets/slider_01/' + item_data.img4)">
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
  .imgMicro{
    width: 255px;
    height: 130px;
  }
</style>
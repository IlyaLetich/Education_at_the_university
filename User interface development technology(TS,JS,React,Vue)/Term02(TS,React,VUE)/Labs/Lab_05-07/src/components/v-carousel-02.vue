<template>
<div class="Block" id="slideerrman">
  <div class="text1_02">
    Отзывы
  </div>
  <div class="text2">
    Ваши благодарности
  </div>
  <div class="wrapper">
    <div class="vCarouselItem" :style = "{ 'margin-left': '-' + (1070 * currentSlideIndex) + 'px'}">
      <v_carousel_item
        v-for="item in carousel_Data"
        :key="item.id"
        :item_data = "item"/>
    </div>
    <div class="groupCircle">
      <div class="circle" :style = "{ 'opacity' : checkSlide[0] }"></div>
      <div class="circle" :style = "{ 'opacity' : checkSlide[1] }"></div>
      <div class="circle" :style = "{ 'opacity' : checkSlide[2] }"></div>
      <div class="circle" :style = "{ 'opacity' : checkSlide[3] }"></div>
    </div>
    <button @click="nextSlide">&gt;</button>
    <button @click="prevSlide">&lt;</button>
  </div>
</div>
</template>

<script>
import vCaruselItem from './v-carousel-item-02.vue'

export default {
  name: "v-carousel",
  components: {
    v_carousel_item: vCaruselItem
  },
  props: {
    carousel_Data: {
      type: Array,
      default: () => []
    }
  },
  data(){
    return{
      currentSlideIndex: 0,
      checkSlide: [1,0.2,0.2,0.2]
    }
  },
  methods: {
    prevSlide(){
      if(this.currentSlideIndex == 0){
        this.currentSlideIndex = 3;
        this.checkSlide[this.currentSlideIndex] = 1;
        this.checkSlide[0] = 0.2
      }
      else {
        this.currentSlideIndex--;
        this.checkSlide[this.currentSlideIndex] = 1;
        this.checkSlide[this.currentSlideIndex + 1] = 0.2
      }
    },
    nextSlide(){
      if(this.currentSlideIndex == 3){
        this.currentSlideIndex = 0;
        this.checkSlide[this.currentSlideIndex] = 1;
        this.checkSlide[3] = 0.2
      }
      else {
        this.currentSlideIndex++;
        this.checkSlide[this.currentSlideIndex] = 1;
        this.checkSlide[this.currentSlideIndex - 1] = 0.2
      }
    },
  }
}
</script>

<style scoped>
  .text1_02{
    padding-top: 100px;
    width: 350px;
    height: 23px;
    margin-left: 260px;
    top: 2966px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 900;
    font-size: 24px;
    line-height: 33px;
    color: #BDBDBD;
  }
  .text2{
    padding-top: 40px;
    width: 483px;
    height: 47px;
    margin-left: 260px;
    font-family: 'Merriweather';
    font-style: normal;
    font-weight: 900;
    font-size: 48px;
    color: #333333;
    margin-bottom: 70px;
  }
  .Block{
    height: 750px;
  }
 .wrapper{
    position: absolute;
    width: 1010px;
    overflow: hidden;
    margin: 0 260px;   
 }
  .vCarouselItem{
    transition: all ease .5s;
    display: flex;
  }
  button{
    font-size: 30px;
    color: white;
    margin-top: 50px;
    float: right;
    width: 60px;
    height: 60px;
    background: #005FA3;
    opacity: 0.2;
    border: 0;
  }
  button:hover{
    opacity: 1;
  }
  .groupCircle{
    display: inline;
  }
  .circle {
      width: 10px;
      height: 10px;
      display: inline-block;
      margin-right: 40px;
      border-radius: 5px;
      background: red;
      background: #005FA3;
      opacity: 0.4;
      margin-top: 100px;
    }
</style>
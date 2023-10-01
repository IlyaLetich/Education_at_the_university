<template>
  <div id = "app">
    <v_header/>
    <CarouselWrapper />
    <v_service :service_Data = "service_Items"/>
    <AboutMy :data="dataA" />
    <v_carousel :carousel_Data = "slider_01_Items"/>
    <v_carousel_02 :carousel_Data = "slider_02_Items"/>
    <v_connection />
    <v_footer/>
  </div>
</template>

<script lang="ts">
import vCarousel from './components/v-carousel-01.vue'
import vCarousel_02 from './components/v-carousel-02.vue'
import vConnection from './components/v-connection.vue'
import vFooter from './components/v-footer.vue'
import vHeader from './components/v-header.vue'
import vServise from './components/v-servise.vue'
import CarouselWrapper from './components/CarouselWrapper.vue'
import AboutMy from './components/AboutMy.vue'

export default{
  name: 'app',
  components: {
    CarouselWrapper: CarouselWrapper,
    AboutMy: AboutMy,
    v_header: vHeader,
    v_carousel : vCarousel,
    v_carousel_02: vCarousel_02,
    v_connection: vConnection,
    v_footer: vFooter,
    v_service: vServise
  },
  data(){
    return{
      slider_01_Items: [
        {id: 1, name: 'item1', img1: 'img1.png', img2: 'img1.png', img3: 'img1.png', img4: 'img1.png'},
        {id: 2, name: 'item1', img1: 'img1.png', img2: 'img1.png', img3: 'img1.png', img4: 'img1.png'},
        {id: 3, name: 'item1', img1: 'img1.png', img2: 'img1.png', img3: 'img1.png', img4: 'img1.png'},
        {id: 4, name: 'item1', img1: 'img1.png', img2: 'img1.png', img3: 'img1.png', img4: 'img1.png'},
      ],
      slider_02_Items: [
        {id: 1, name: 'item1', img1: 'img1.png', text1: 'Екатерина Иванова', text2: 'Директор БГТУ', text3: 'Lorem Ipsum - это текст-"рыба", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной "рыбой" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum - это текст-"рыба", часто используемый в печати и вэб-дизайне. '},
        {id: 2, name: 'item1', img1: 'img1.png', text1: 'Екатерина Иванова', text2: 'Директор БГТУ', text3: 'Lorem Ipsum - это текст-"рыба", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной "рыбой" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum - это текст-"рыба", часто используемый в печати и вэб-дизайне. '},
        {id: 3, name: 'item1', img1: 'img1.png', text1: 'Екатерина Иванова', text2: 'Директор БГТУ', text3: 'Lorem Ipsum - это текст-"рыба", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной "рыбой" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum - это текст-"рыба", часто используемый в печати и вэб-дизайне. '},
        {id: 4, name: 'item1', img1: 'img1.png', text1: 'Екатерина Иванова', text2: 'Директор БГТУ', text3: 'Lorem Ipsum - это текст-"рыба", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной "рыбой" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum - это текст-"рыба", часто используемый в печати и вэб-дизайне. '},
      ],
      service_Items: [
        {id: 1, name: 'item1', img1: 'img1.png', text1: "Бухгалтерское обслуживание", text2: "Описание 1"},
        {id: 2, name: 'item1', img1: 'img1.png', text1: "Бухгалтерское обслуживание", text2: "Описание 2"},
        {id: 3, name: 'item1', img1: 'img1.png', text1: "Бухгалтерское обслуживание", text2: "Описание 3"},
        {id: 4, name: 'item1', img1: 'img1.png', text1: "Бухгалтерское обслуживание", text2: "Описание 4"},
        {id: 5, name: 'item1', img1: 'img1.png', text1: "Бухгалтерское обслуживание", text2: "Описание 5"},
        {id: 6, name: 'item1', img1: 'img1.png', text1: "Бухгалтерское обслуживание", text2: "Описание 6"},
      ],
      dataA: [
        {
            id: 1,
            num: '90',
            text: 'Завершено крупных сделок',
            link: 'Все кейсы',
        },
        {
           id: 2,
           num: '90',
           text: 'Завершено крупных сделок',
           link: 'Все кейсы',
        },
        {
           id: 3,
           num: '90',
           text: 'Завершено крупных сделок',
           link: 'Все кейсы',
        },
        {
           id: 4,
           num: '90',
           text: 'Завершено крупных сделок',
           link: 'Все кейсы',
        },
      ],

    }
  },
}
</script>

<style>
  * {
      margin: 0;
      padding: 0;
    }
</style>

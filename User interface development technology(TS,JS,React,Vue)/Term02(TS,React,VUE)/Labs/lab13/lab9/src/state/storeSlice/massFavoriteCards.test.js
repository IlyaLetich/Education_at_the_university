import FavoriteCardsReducer, {setLikeState} from './massFavoriteCards'

let state = {
    mode:   [ 
    {id:0,shedule:"FullDay",employment:"FullEmployment",between:"NotExperience",income:"1000",corpName:"Интернет Люди",imageSrc:null, jobName:"Frontend (React)",counName:"Москва",tags:["JavaScript","React","TypeScript"],isLiked:false  ,date:"05.01.2004",text:["Мы, Winfinity, занимаемся разработкой инновационных решений в области игорно-развлекательного контента.","Для создания наших продуктов используются передовые технологии, среди которых: Computer Vision, Unreal Engine, Ultra Low Latency Video Streaming. У нас очень крутой и суперсовременный технопарк - от камер и света, до графических карт, которые почти невозможно найти.","Сегодня мы на стадии активного развития. Мы создаём масштабный, технологически сложный и в тоже время очень интересный, глобальный проект - частью которого можете стать Вы!","И если у Вас есть:","опыт коммерческой разработки на JavaScript от 2 лет;","опыт коммерческой разработки на React от 2 лет;","опыт работы в команде с git;"],cost:"От 150 000 до 300 000 руб."},
    {id:1,shedule:"DistanceWork",employment:"Part-timeEmployment",between:"BetweenOneToThree",income:"5000",corpName:"Интернет Люди", jobName:"Frontend developer corparation",counName:"Москва",tags:["JavaScript","React"],isLiked:false  ,date:"05.01.2004",text:["Мы, Winfinity, занимаемся разработкой инновационных решений в области игорно-развлекательного контента.","Для создания наших продуктов используются передовые технологии, среди которых: Computer Vision, Unreal Engine, Ultra Low Latency Video Streaming. У нас очень крутой и суперсовременный технопарк - от камер и света, до графических карт, которые почти невозможно найти.","Сегодня мы на стадии активного развития. Мы создаём масштабный, технологически сложный и в тоже время очень интересный, глобальный проект - частью которого можете стать Вы!","И если у Вас есть:","опыт коммерческой разработки на JavaScript от 2 лет;","опыт коммерческой разработки на React от 2 лет;","опыт работы в команде с git;"],cost:"От 150 000 до 300 000 руб."},
    {id:2,shedule:"SmartSchedule",employment:"FullEmployment",between:"BetweenThreeToSix",income:"7000",corpName:"Интернет Люди", jobName:"Nikita developer (React)",counName:"Питер",tags:["JavaScript","C#"],isLiked:true  ,date:"05.01.2004",text:["Мы, Winfinity, занимаемся разработкой инновационных решений в области игорно-развлекательного контента.","Для создания наших продуктов используются передовые технологии, среди которых: Computer Vision, Unreal Engine, Ultra Low Latency Video Streaming. У нас очень крутой и суперсовременный технопарк - от камер и света, до графических карт, которые почти невозможно найти.","Сегодня мы на стадии активного развития. Мы создаём масштабный, технологически сложный и в тоже время очень интересный, глобальный проект - частью которого можете стать Вы!","И если у Вас есть:","опыт коммерческой разработки на JavaScript от 2 лет;","опыт коммерческой разработки на React от 2 лет;","опыт работы в команде с git;"],cost:"От 150 000 до 300 000 руб."},
    ]   
  };

describe('massFavoriteCards tests',()=>{
    it('The property should not be undefined', () =>{
        expect(FavoriteCardsReducer(state,setLikeState({id:0})).mode[0].isLiked).toBeDefined()
    })
    it('The property should not be undefined truthy', () => {
        expect(FavoriteCardsReducer(state,setLikeState({id:1})).mode[1].isLiked).toBeTruthy()
    })
    it('The property should not be undefined falsy', () => {
        expect(FavoriteCardsReducer(state,setLikeState({id:2})).mode[2].isLiked).toBeFalsy()
    })
})
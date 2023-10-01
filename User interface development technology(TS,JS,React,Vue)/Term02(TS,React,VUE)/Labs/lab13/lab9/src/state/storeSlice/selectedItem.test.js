import SelectedItemReducer, { setObject,setNull } from './selectedItem'

let state = {
    mode: ""
}

let card = {id:0,shedule:"FullDay",employment:"FullEmployment",between:"NotExperience",income:"1000",corpName:"Интернет Люди",imageSrc:null, jobName:"Frontend (React)",counName:"Москва",tags:["JavaScript","React","TypeScript"],isLiked:false  ,date:"05.01.2004",text:["Мы, Winfinity, занимаемся разработкой инновационных решений в области игорно-развлекательного контента.","Для создания наших продуктов используются передовые технологии, среди которых: Computer Vision, Unreal Engine, Ultra Low Latency Video Streaming. У нас очень крутой и суперсовременный технопарк - от камер и света, до графических карт, которые почти невозможно найти.","Сегодня мы на стадии активного развития. Мы создаём масштабный, технологически сложный и в тоже время очень интересный, глобальный проект - частью которого можете стать Вы!","И если у Вас есть:","опыт коммерческой разработки на JavaScript от 2 лет;","опыт коммерческой разработки на React от 2 лет;","опыт работы в команде с git;"],cost:"От 150 000 до 300 000 руб."}

describe('SelectedItemReducer tests',()=>{
    it('The object is not empty',()=>{
        expect(SelectedItemReducer(state,setObject(card)).mode).toBeTruthy();
    })
    it('The object is empty', () =>{
        expect(SelectedItemReducer({mode:card},setNull()).mode).toBeFalsy();
    })
    it('The object has fields',()=>{
        expect(SelectedItemReducer(state,setObject(card)).mode).toEqual(card);
    })
})
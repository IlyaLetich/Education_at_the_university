import FillterReducer, { setCountry,setBetween,setEmployment,setIncome,setSchedule } from './FilterSlice'

let state = {
    modeCountry: "",
    modeSchedule: "",
    modeEmployment: "",
    modeBetween: "",
    modeIncome: ""
  };

describe('FillterReducer test',()=>{

    it('Country must be Mir', () =>{
        expect(FillterReducer(state,setCountry("Mir")).modeCountry).toBe("Mir")
    })
    it('Schedule should be undefined', ()=>{
        expect(FillterReducer(state,setSchedule(undefined)).modeSchedule).toBeUndefined()
    })
    it('Employment should be contain Postavy',()=>{
        expect(FillterReducer(state,setEmployment("PostavyMir")).modeEmployment).toContain("Postavy")
    })
    it('Between length must be equal to 11', () =>{
        expect(FillterReducer(state,setBetween("Baranovichi")).modeBetween).toHaveLength(11)
    })
    it('Income must pass the regular expression',()=>{
        expect(FillterReducer(state,setIncome("100-2000")).modeIncome).toMatch(/^\d*-\d*$/)
    })

})


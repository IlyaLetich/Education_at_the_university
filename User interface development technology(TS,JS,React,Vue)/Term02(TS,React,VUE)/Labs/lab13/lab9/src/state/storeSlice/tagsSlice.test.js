import TagsReducer, {setTag} from "./tagsSlice";

let state = {
    mode: []
}

describe('tagsReducer tests',()=>{
    it('Adding a tag',()=>{
        expect(TagsReducer(state,setTag("Mir")).mode).toContain("Mir")
    })
    it('Removing a tag',()=>{
        expect(TagsReducer({mode:["Postavy"]},setTag("Postavy")).mode).not.toContain("Postavy")
    })
    it('The number of tags should increase',()=>{
        let state = {
            mode: ["Mir","Postavy","Baranovichy"]
        }
        state = TagsReducer(state,setTag("Stalbtsy"))
        state = TagsReducer(state,setTag("Grodno"))
        expect(state.mode.length).toBeGreaterThan(3)
    })
})
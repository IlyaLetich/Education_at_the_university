import StoreReducer, {toggleMode} from "./storeSlice"

let state = {
    mode: "Search",
}


describe('StoreReducer tests',()=>{
    it('The state should change',() =>{
        expect(StoreReducer(state, toggleMode("Favorite")).mode).toBe("Favorite")
    })
    it('The state shouldn\'t change', () => {
        expect(StoreReducer(state, toggleMode("Postavy")).mode).toBe("Search")
    })
})
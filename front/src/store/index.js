import { createStore } from 'vuex'
import Ability from '../services/ability'

export default createStore({
  state: {
    listAbilities: []
  },
  getters: {
    nameAbilities(state){
      return state.listAbilities.map( (hability) => {
        return {
          label: hability.name,
          value: hability.id
        }
      })
    }
  },
  mutations: {
    UPDATE_LIST_ABILITIES(state){

      Ability.updateList().then((resp) => {
        state.listAbilities = resp.data.abilities
      })

    }
  },
  actions: {
  },
  modules: {
  }
})

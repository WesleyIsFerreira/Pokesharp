import { http } from './config'

export default {
    create:(parans) => {
        return http.post('api/pokedex/createability', parans)
    },

    updateList:() => {
        return http.get('api/pokedex/listabilities')
    }
}
import { http } from './config'

export default {
    create:(parans) => {
        return http.post('api/pokedex/createability', parans)
    },

    list:() => {
        return http.get('api/pokedex/listabilities')
    }
}
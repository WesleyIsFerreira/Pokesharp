import { http } from './config'

export default {
    create:(parans) => {
        var formData = new FormData()
        formData.append('Name', parans.Name)
        formData.append('Description', parans.Description)
        formData.append('Category', parans.Category)
        formData.append('Gender', parans.Gender)
        formData.append('Height', parans.Height)
        formData.append('Weight', parans.Weight)
        formData.append('Type', parans.Type)
        formData.append('Weaknesses', parans.Weaknesses)
        formData.append('Photo', parans.Photo)

        for (let i = 0; i < parans.Abilities.length; i++) {
            formData.append('Abilities[]', parans.Abilities[i]);
        }
        
        return http.post('api/pokedex/createpokemon', formData)
    },
}
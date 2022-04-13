import { http } from './config'

export default {
    create:(parans) => {
        console.log('AQuiiiiiii',parans)
        var formData = new FormData()
        formData.append('username', 'Chris')
        formData.append('Name', parans.Name)
        formData.append('Description', parans.Description)
        formData.append('Category', parans.Category)
        formData.append('Gender', parans.Gender)
        formData.append('Height', parans.Height)
        formData.append('Weight', parans.Weight)
        formData.append('Type', parans.Type)
        formData.append('Weaknesses', parans.Weaknesses)
        formData.append('Abilities', parans.Abilities)
        formData.append('Photo', parans.Photo)
        return http.post('api/pokedex/createpokemon', formData)
    },
}
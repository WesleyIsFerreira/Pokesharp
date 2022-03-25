<template>
    <div class="modal fade fixed top-0 left-0 hidden w-full h-full outline-none overflow-x-hidden overflow-y-auto" id="createPokemonModal" ref="createPokemonModal" tabindex="-1" aria-labelledby="createPokemonModalTitle" aria-modal="true" role="dialog">
        <div class="modal-dialog modal-dialog-centered relative w-auto pointer-events-none">
            <div class="modal-content border-none shadow-lg relative flex flex-col w-full pointer-events-auto bg-white bg-clip-padding rounded-md outline-none text-current">
                <div class="modal-header flex flex-shrink-0 items-center justify-between p-4 border-b border-gray-200 rounded-t-md">
                    <h5 class="text-xl font-medium leading-normal text-gray-800" id="exampleModalScrollableLabel">
                        Criar Pokemon
                    </h5>
                    <button type="button"
                    id="btnClose"
                    class="btn-close box-content w-4 h-4 p-1 text-black border-none rounded-none opacity-50 focus:shadow-none focus:outline-none focus:opacity-100 hover:text-black hover:opacity-75 hover:no-underline"
                    data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <form @submit.prevent="savePokemon()">
                    <div class="modal-body relative p-4">
                        <div class="flex justify-center">
                            <div>
                                <div class="mb-3 xl:w-96">

                                    <label for="namePokemon" class="label-form">Nome</label>
                                    <input
                                        autocomplete="off"
                                        v-model="pokemon.name"
                                        type="text"
                                        class="input-form"
                                        id="namePokemon"
                                        placeholder="Digite o nome"
                                    />

                                    <label for="descriptionPokemon" class="label-form" >Descrição</label>
                                    <textarea
                                        rows="3"
                                        autocomplete="off"
                                        v-model="pokemon.description"
                                        type="text"
                                        class="input-form"
                                        id="descriptionPokemon"
                                        placeholder="Digite a descrição"
                                    />

                                    <label for="categoryPokemon" class="label-form">Categoria</label>
                                    <input
                                        autocomplete="off"
                                        v-model="pokemon.category"
                                        type="text"
                                        class="input-form"
                                        id="categoryPokemon"
                                        placeholder="Digite a categoria"
                                    />

                                    <label for="genderPokemon" class="label-form">Genero</label>
                                    <select v-model="pokemon.gender" id="genderPokemon" class="select-form" aria-label=".form-select-sm example">
                                        <option value="unknown" selected>Desconhecido</option>
                                        <option value="male">Masculino</option>
                                        <option value="female">Feminino</option>
                                        <option value="both">Ambos</option>
                                    </select>

                                    <div class="grid grid-cols-2">
                                        <div class="mr-1">
                                            <label for="heightPokemon" class="label-form">Altura</label>
                                            <input
                                                autocomplete="off"
                                                v-model="pokemon.height"
                                                type="number"
                                                class="input-form"
                                                id="heightPokemon"
                                                placeholder="Digite a altura"
                                            />
                                        </div>
                                        <div class="ml-1">
                                            <label for="weightPokemon" class="label-form">Largura</label>
                                            <input
                                                autocomplete="off"
                                                v-model="pokemon.weight"
                                                type="number"
                                                class="input-form"
                                                id="weightPokemon"
                                                placeholder="Digite a largura"
                                            />
                                        </div>
                                    </div>

                                    <div class="grid grid-cols-2">
                                        <div class="mr-1">
                                            <label for="heightPokemon" class="label-form">Tipo</label>
                                            <select v-model="pokemon.gender" id="genderPokemon" class="select-form" aria-label=".form-select-sm example">
                                                <option value="unknown" selected>Desconhecido</option>
                                                <option value="male">Masculino</option>
                                                <option value="female">Feminino</option>
                                                <option value="both">Ambos</option>
                                            </select>
                                        </div>
                                        <div class="ml-1">
                                            <label for="weightPokemon" class="label-form">Largura</label>
                                            <input
                                                autocomplete="off"
                                                v-model="pokemon.weight"
                                                type="number"
                                                class="input-form"
                                                id="weightPokemon"
                                                placeholder="Digite a largura"
                                            />
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer flex flex-shrink-0 flex-wrap items-center justify-end p-4 border-t border-gray-200 rounded-b-md">
                        <button type="button"
                        :disabled="loading"
                        :class="[loading ? 'bg-gray-300 hover:bg-gray-300 focus:bg-gray-300' : 'bg-purple-600  hover:bg-purple-700 focus:bg-purple-700']"
                        class="inline-block px-6 py-2.5 text-white font-medium text-xs leading-tight uppercase rounded shadow-md hover:shadow-lg focus:shadow-lg focus:outline-none focus:ring-0 active:bg-purple-800 active:shadow-lg transition duration-150 ease-in-out"
                        data-bs-dismiss="modal">
                            Fechar
                        </button>
                        <button type="submit"
                        :disabled="loading"
                        :class="[loading ? 'bg-gray-300 hover:bg-gray-300 focus:bg-gray-300' : 'bg-blue-600 hover:bg-blue-700 focus:bg-blue-700']"
                        class="inline-block px-6 py-2.5  text-white font-medium text-xs leading-tight uppercase rounded shadow-md  hover:shadow-lg  focus:shadow-lg focus:outline-none focus:ring-0 active:bg-blue-800 active:shadow-lg transition duration-150 ease-in-out ml-1">
                            <div v-if="loading" class="flex justify-center items-center">
                                <div class="spinner-border animate-spin inline-block w-4 h-4 border-4 rounded-full" role="status">
                                <span class="visually-hidden">Loading...</span>
                                </div>
                            </div>
                            <div v-else>
                                Salvar
                            </div>
                        </button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
import { reactive, ref } from '@vue/reactivity'
import Pokemon from '../../services/ability'
export default {
    name: 'InsertPokemonModal',
    setup(){
        //setando para usar o toast
        const { toast } = require('tailwind-toast')
        const createPokemonModal = ref(null);

        //Criação de abilidades
        const pokemon = reactive({name:'', description:''})
        function savePokemon(){
            const newPokemon = {
                Name: pokemon.name,
                Description: pokemon.description
            }

            if (!newPokemon.Name || !newPokemon.Description){

                let div = document.getElementsByClassName('modal-backdrop')[0]
                div.classList.add("z-40")

                toast()
                    .default('Atenção:','Campos em branco :(')
                    .with({
                        shape: 'pill',
                        duration: 3000,
                        speed: 1000,
                        positionX: 'end',
                        positionY: 'top',
                        color: 'bg-yellow-300',
                        fontColor: 'text-black',
                        fontTone: 200
                    })
                    .show()
                return
            }

            startLoading()

            Pokemon.create(newPokemon).then( () => {
                
                stopLoading()

                let div = document.getElementsByClassName('modal-backdrop')[0]
                div.classList.add("z-40")

                toast()
                    .default('Sucesso:','Habilidade criada')
                    .with({
                        shape: 'pill',
                        duration: 3000,
                        speed: 1000,
                        positionX: 'end',
                        positionY: 'top',
                        color: 'bg-green-500',
                        fontColor: 'text-black',
                        fontTone: 200
                    })
                    .show()

                document.getElementById('btnClose').click()

                pokemon.name = ''
                pokemon.description = ''
                
            }).catch(function (error) {
                if (error.response) {
                    if (error.response.data.errors)
                        toast()
                        .default('Atenção:',error.response.data.errors[0].errorMessage)
                        .with({
                            shape: 'pill',
                            duration: 3000,
                            speed: 1000,
                            positionX: 'end',
                            positionY: 'top',
                            color: 'bg-yellow-300',
                            fontColor: 'white',
                            fontTone: 200
                        })
                        .show()
                    else
                        toast()
                        .default('Erro:', 'Entre inesperado')
                        .with({
                            shape: 'pill',
                            duration: 3000,
                            speed: 1000,
                            positionX: 'end',
                            positionY: 'top',
                            color: 'bg-red-300',
                            fontColor: 'white',
                            fontTone: 200
                        })
                        .show()
                }
                stopLoading()
            })
            
        }

        //Setando Loadings
        const loading = ref(false)

        function startLoading(){
            loading.value = true
        }

        function stopLoading(){
            loading.value = false
        }

        return{
            loading,
            startLoading,
            stopLoading,
            savePokemon,
            pokemon,
            createPokemonModal
        }
    }
}
</script>

<style>

</style>
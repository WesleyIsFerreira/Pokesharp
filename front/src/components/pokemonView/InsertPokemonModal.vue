<template>
  <div
    class="
      modal
      fade
      fixed
      top-0
      left-0
      hidden
      w-full
      h-full
      outline-none
      overflow-x-hidden overflow-y-auto
    "
    id="createPokemonModal"
    ref="createPokemonModal"
    tabindex="-1"
    aria-labelledby="createPokemonModalTitle"
    aria-modal="true"
    role="dialog"
  >
    <div
      class="
        modal-dialog modal-dialog-centered
        relative
        w-auto
        pointer-events-none
      "
    >
      <div
        class="
          modal-content
          border-none
          shadow-lg
          relative
          flex flex-col
          w-full
          pointer-events-auto
          bg-white bg-clip-padding
          rounded-md
          outline-none
          text-current
        "
      >
        <div
          class="
            modal-header
            flex flex-shrink-0
            items-center
            justify-between
            p-4
            border-b border-gray-200
            rounded-t-md
          "
        >
          <h5
            class="text-xl font-medium leading-normal text-gray-800"
            id="exampleModalScrollableLabel"
          >
            Criar Pokemon
          </h5>
          <button
            type="button"
            id="btnClose"
            class="
              btn-close
              box-content
              w-4
              h-4
              p-1
              text-black
              border-none
              rounded-none
              opacity-50
              focus:shadow-none focus:outline-none focus:opacity-100
              hover:text-black hover:opacity-75 hover:no-underline
            "
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <form @submit.prevent="savePokemon()">
          <div class="modal-body relative p-4">
            <div class="flex justify-center">
              <div>
                <div class="mb-3 xl:w-96">

                  <div class="grid grid-cols-2"> 
                    <div>
                      <label for="imgPokeon" class="label-form">Foto</label><br />
                      <div class="h-24 relative bg-gray-200 p-1">
                        <button 
                          @click="clearImg()" 
                          label="Procurar imagem" 
                          type="button" 
                          class="
                            absolute
                            right-1
                            top-1
                            inline-block 
                            px-2 py-1.5 
                            bg-red-500 
                            text-white 
                            font-medium 
                            text-xs 
                            leading-tight 
                            uppercase 
                            rounded 
                            shadow-md 
                            hover:bg-red-600 hover:shadow-lg 
                            focus:bg-red-600 focus:shadow-lg focus:outline-none focus:ring-0 
                            transition duration-150 ease-in-out
                          "
                        >
                          <fa icon="minus" />
                        </button>
                        <button 
                          @click="$refs.EventfileInput.click()" 
                          label="Procurar imagem" 
                          type="button" 
                          class="
                            absolute
                            right-1
                            bottom-1
                            inline-block 
                            px-2 py-1.5 
                            bg-blue-500 
                            text-white 
                            font-medium 
                            text-xs 
                            leading-tight 
                            uppercase 
                            rounded 
                            shadow-md 
                            hover:bg-blue-600 hover:shadow-lg 
                            focus:bg-blue-600 focus:shadow-lg focus:outline-none focus:ring-0 
                            transition duration-150 ease-in-out
                          "
                        >
                          <fa icon="plus" />
                        </button>
                        <input style="display:none" ref="EventfileInput" @change="onEventFilePicked" type="file" name="upload" accept="image/*" required />
                        <img class="h-full mx-auto" :src="imageUrl" />
                      </div>
                    </div>
                    <div class="pl-2">
                      <label for="namePokemon" class="label-form">Nome</label>
                      <input
                        autocomplete="off"
                        v-model="pokemon.name"
                        type="text"
                        class="input-form"
                        id="namePokemon"
                        placeholder="Digite o nome"
                        required
                      />
                    </div>
                  </div>

                  <label for="descriptionPokemon" class="label-form"
                    >Descrição</label
                  >
                  <textarea
                    rows="3"
                    autocomplete="off"
                    v-model="pokemon.description"
                    type="text"
                    class="input-form"
                    id="descriptionPokemon"
                    placeholder="Digite a descrição"
                    required
                  />

                  <label for="categoryPokemon" class="label-form"
                    >Categoria</label
                  >
                  <input
                    autocomplete="off"
                    v-model="pokemon.category"
                    type="text"
                    class="input-form"
                    id="categoryPokemon"
                    placeholder="Digite a categoria"
                    required
                  />

                  <label for="genderPokemon" class="label-form">Genero</label>
                  <select
                    v-model="pokemon.gender"
                    id="genderPokemon"
                    class="select-form"
                    aria-label=".form-select-sm example"
                  >
                    <option value="unknown" selected>Desconhecido</option>
                    <option value="masculine">Masculino</option>
                    <option value="female">Feminino</option>
                    <option value="both">Ambos</option>
                  </select>

                  <div class="grid grid-cols-2">
                    <div class="mr-1">
                      <label for="heightPokemon" class="label-form"
                        >Altura</label
                      >
                      <input
                        autocomplete="off"
                        v-model="pokemon.height"
                        type="number"
                        class="input-form"
                        id="heightPokemon"
                        placeholder="Digite a altura"
                        required
                      />
                    </div>
                    <div class="ml-1">
                      <label for="weightPokemon" class="label-form"
                        >Largura</label
                      >
                      <input
                        autocomplete="off"
                        v-model="pokemon.weight"
                        type="number"
                        class="input-form"
                        id="weightPokemon"
                        placeholder="Digite a largura"
                        required
                      />
                    </div>
                  </div>
                  <label for="abilityPokemon" class="label-form"
                    >Habilidades</label
                  >
                  <Multiselect
                    id="abilityPokemon"
                    v-model="abilitiesPk"
                    :options="listAbilities"
                    mode="tags"
                    :close-on-select="false"
                    :searchable="true"
                    required
                  />
                  <label for="heightPokemon" class="label-form">Tipo</label>
                  <Multiselect
                    id="heightPokemon"
                    v-model="typePk"
                    :options="options"
                    mode="tags"
                    :close-on-select="false"
                    :searchable="true"
                    required
                  />
                  <label for="weightPokemon" class="label-form">Fraqueza</label>
                  <Multiselect
                    id="weightPokemon"
                    v-model="weaknessesPk"
                    :options="options"
                    mode="tags"
                    :close-on-select="false"
                    :searchable="true"
                    required
                  />
                </div>
              </div>
            </div>
          </div>
          <div
            class="
              modal-footer
              flex flex-shrink-0 flex-wrap
              items-center
              justify-end
              p-4
              border-t border-gray-200
              rounded-b-md
            "
          >
            <button
              type="button"
              :disabled="loading"
              :class="[
                loading
                  ? 'bg-gray-300 hover:bg-gray-300 focus:bg-gray-300'
                  : 'bg-purple-600  hover:bg-purple-700 focus:bg-purple-700',
              ]"
              class="
                inline-block
                px-6
                py-2.5
                text-white
                font-medium
                text-xs
                leading-tight
                uppercase
                rounded
                shadow-md
                hover:shadow-lg
                focus:shadow-lg focus:outline-none focus:ring-0
                active:bg-purple-800 active:shadow-lg
                transition
                duration-150
                ease-in-out
              "
              data-bs-dismiss="modal"
            >
              Fechar
            </button>
            <button
              type="submit"
              :disabled="loading"
              :class="[
                loading
                  ? 'bg-gray-300 hover:bg-gray-300 focus:bg-gray-300'
                  : 'bg-blue-600 hover:bg-blue-700 focus:bg-blue-700',
              ]"
              class="
                inline-block
                px-6
                py-2.5
                text-white
                font-medium
                text-xs
                leading-tight
                uppercase
                rounded
                shadow-md
                hover:shadow-lg
                focus:shadow-lg focus:outline-none focus:ring-0
                active:bg-blue-800 active:shadow-lg
                transition
                duration-150
                ease-in-out
                ml-1
              "
            >
              <div v-if="loading" class="flex justify-center items-center">
                <div
                  class="
                    spinner-border
                    animate-spin
                    inline-block
                    w-4
                    h-4
                    border-4
                    rounded-full
                  "
                  role="status"
                >
                  <span class="visually-hidden">Loading...</span>
                </div>
              </div>
              <div v-else>Salvar</div>
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive, ref } from "@vue/reactivity"
import Pokemon from "../../services/pokemon"
import Multiselect from "@vueform/multiselect"
import { useStore } from "vuex"
import { computed } from "@vue/runtime-core"

export default {
  name: "InsertPokemonModal",
  components: {
    Multiselect
  },
  props: ["testProp"],
  setup() {
    const store = useStore()

    //setando habilidades
    store.commit("UPDATE_LIST_ABILITIES")
    const listAbilities = computed(() => store.getters.nameAbilities)
    const abilities = ref(null)

    //setando tipos e fraquezas
    const types = ref(null)
    const weaknesses = ref(null)
    const options = ref([
      { value: "normal", label: "Normal" },
      { value: "fire", label: "fogo" },
      { value: "water", label: "água" },
      { value: "grass", label: "grama" },
      { value: "flying", label: "voador" },
      { value: "fighting", label: "lutador" },
      { value: "poison", label: "veneno" },
      { value: "electric", label: "elétrico" },
      { value: "ground", label: "terra" },
      { value: "rock", label: "pedra" },
      { value: "psychic", label: "psíquico" },
      { value: "ice", label: "gelo" },
      { value: "bug", label: "inseto" },
      { value: "ghost", label: "fantasma" },
      { value: "steel", label: "ferro" },
      { value: "dragon", label: "dragão" },
      { value: "dark", label: "sombrio" },
      { value: "fairy", label: "fada" },
    ])

    //setando para usar o toast
    const { toast } = require("tailwind-toast")

    //setando imagem pokemon
    const imageUrl = ref('img/default.jpg')
    const EventfileInput = ref(null)
      
    const onEventFilePicked = (event) => {
      const files = event.target.files
      const image = files[0]
      console.log(image)
      const filename = files[0].name
      if (filename.lastIndexOf('.') <= 0) {
        return alert('Por favor adicione um arquivo válido')
      }
      const fileReader = new FileReader()
      fileReader.addEventListener('load', () => {
        imageUrl.value = fileReader.result
      })
      fileReader.readAsDataURL(files[0])
      photoPK.value = image

      console.log(photoPK.value)
    }

    function clearImg(){
      imageUrl.value = 'img/default.jpg'
      EventfileInput.value.value = ''
    }

    //Criação de pokemon
    const pokemon = reactive({
      name: "",
      description: "",
      category: "",
      gender: "",
      height: "",
      weight: ""
    })

    const photoPK = ref(File)
    const abilitiesPk = ref([])
    const typePk = ref([])
    const weaknessesPk = ref([])

    function savePokemon() {
      const newPokemon = {
        Name: pokemon.name,
        Description: pokemon.description,
        Category: pokemon.category,
        Gender: pokemon.gender,
        Height: pokemon.height,
        Weight: pokemon.weight,
        Type: typePk.value,
        Weaknesses: weaknessesPk.value,
        Abilities: abilitiesPk.value,
        Photo: photoPK.value
      }

      startLoading()

      Pokemon.create(newPokemon)
        .then(( resp ) => {
          stopLoading()
          console.log(resp)
          let div = document.getElementsByClassName("modal-backdrop")[0]
          div.classList.add("z-40")

          toast()
            .default("Sucesso:", "Habilidade criada")
            .with({
              shape: "pill",
              duration: 3000,
              speed: 1000,
              positionX: "end",
              positionY: "top",
              color: "bg-green-500",
              fontColor: "text-black",
              fontTone: 200,
            })
            .show()

          document.getElementById("btnClose").click()

          pokemon.name = ""
          pokemon.description = ""
        })
        .catch(function (error) {
          stopLoading()
          if (error.response) {
            let div = document.getElementsByClassName("modal-backdrop")[0]
            div.classList.add("z-40")
            if (error.response.data.errors)
              toast()
                .default("Atenção:", error.response.data.errors[0].errorMessage)
                .with({
                  shape: "pill",
                  duration: 3000,
                  speed: 1000,
                  positionX: "end",
                  positionY: "top",
                  color: "bg-yellow-300",
                  fontColor: "white",
                  fontTone: 200,
                })
                .show()
            else
              toast()
                .default("Erro:", "Erro inesperado")
                .with({
                  shape: "pill",
                  duration: 3000,
                  speed: 1000,
                  positionX: "end",
                  positionY: "top",
                  color: "bg-red-300",
                  fontColor: "white",
                  fontTone: 200,
                })
                .show()
          }
          stopLoading()
        })
    }

    //Setando Loadings
    const loading = ref(false)

    function startLoading() {
      loading.value = true
    }

    function stopLoading() {
      loading.value = false
    }

    return {
      loading,
      startLoading,
      stopLoading,
      savePokemon,
      pokemon,
      options,
      types,
      weaknesses,
      abilities,
      listAbilities,
      typePk,
      weaknessesPk,
      abilitiesPk,
      imageUrl,
      clearImg,
      onEventFilePicked,
      EventfileInput,
      photoPK
    }
  },
}
</script>

<style src="@vueform/multiselect/themes/default.css"></style>
<template>
    <div>
        <NavBarVue page="Pokemons"/>

        <div class="float-right">
        <button class="btn-success mx-2 mt-2" type="button" data-bs-toggle="modal" data-bs-target="#createAbilityModal">
            <fa icon="plus" /> Criar Habilidade
        </button>
        <br />
        <button id="btnCreatePoemon" class="btn-success mx-2 mt-2" type="button" data-bs-toggle="modal" data-bs-target="#createPokemonModal">
            <fa icon="plus" /> Criar Pokemon
        </button>
        </div>

        <ModalAddAbility />

        <ModalAddPokemon />

    </div>
</template>

<script>
import NavBarVue from '../components/NavBar.vue'
import ModalAddAbility from '../components/pokemonView/InsertAbilityModal.vue'
import ModalAddPokemon from '../components/pokemonView/InsertPokemonModal.vue'


export default {
    name: 'Pokemons',
    components: {
        NavBarVue,
        ModalAddAbility,
        ModalAddPokemon
    },
    setup(){
      
    }
}
</script>
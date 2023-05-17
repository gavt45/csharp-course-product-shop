<script setup lang="ts">
import { onUpdated } from 'vue';
import TheWelcome from '../components/TheWelcome.vue'
import {ref, computed} from 'vue';
import {useRouter} from 'vue-router';
import { onMounted } from 'vue';

// const columns = ref([
//   {
//     name: 'desc',
//     required: true,
//     label: 'Dessert (100g serving)',
//     align: 'left',
//     field: (row: {name: string}) => row.name,
//     format: (val: any) => `${val}`,
//     sortable: true
//   },
//   { name: 'calories', align: 'center', label: 'Calories', field: 'calories', sortable: true },
//   { name: 'fat', label: 'Fat (g)', field: 'fat', sortable: true },
//   { name: 'carbs', label: 'Carbs (g)', field: 'carbs' }
// ])

// const rows = [
//   {
//     name: 'Frozen Yogurt',
//     calories: 159,
//     fat: 6.0,
//     carbs: 24
//   },
// ];
const expanded = ref(false)
const filter = ref('');
const products = ref([]);
const router = useRouter()

function getProducts() {
  fetch('http://localhost:5265/api/v1/products')
    .then(response => response.json())
    .then(data => products.value = data)
}

function onDelete(id: any, event: any) {
  event.target.disabled = true;
  deleteProduct(id);
  event.target.disabled = false;
}

function deleteProduct(id: any) {
  fetch('http://localhost:5265/api/v1/products/' + id, {method: 'DELETE'})
      // .then((response)=>response.json())
      .then((responseJson)=>{getProducts()});
}

var _ = setInterval(function() {
  getProducts();
}, 5000);

// router.beforeEach(() => getProducts());

onMounted(() => getProducts());
</script>

<style>
.my-card {
  width: 100%;
  max-width: 350px;
}
</style>

<template>
  <q-page class="q-pa-md">
    <div class="q-pa-md row items-start q-gutter-md">
      
      <!-- <q-btn @click="" color="Primary">Fetch</q-btn> -->
      
      <!-- <p v-for="product in products">{{ product }}</p> -->

      <q-card v-for="product in products" class="my-card" flat bordered>
        <q-img :src=product.picture />

        <q-card-section>
          <div class="text-overline text-orange-9">Overline</div>
          <div class="text-h5 q-mt-sm q-mb-xs">{{ product.name }}</div>
          <div class="text-caption text-grey">
            {{ product.description }}
          </div>
        </q-card-section>

        <q-card-actions>
          <q-btn flat color="warning" label="Delete" @click="onDelete(product.id, $event)" />
          <q-btn flat color="secondary" label="Book" />

          <q-space />

          <q-btn
            color="grey"
            round
            flat
            dense
            :icon="expanded ? 'keyboard_arrow_up' : 'keyboard_arrow_down'"
            @click="expanded = !expanded"
          />
        </q-card-actions>

        <q-slide-transition>
          <div v-show="expanded">
            <q-separator />
            <q-card-section class="text-subitle2">
              text
            </q-card-section>
          </div>
        </q-slide-transition>
      </q-card>
    </div>

    <q-page-sticky position="bottom-right" :offset="[18, 18]">
      <q-btn fab icon="add" color="accent" @click="router.push('/create');"/>
    </q-page-sticky>
  </q-page>
  <!-- <div class="q-pa-md">
    <-- <div class="row justify-between"> 

      <-- <q-parallax
      src="https://cdn.quasar.dev/img/parallax2.jpg"
    > -
      <h1>Danil LOH</h1>
      <q-btn color="primary" label="Primary" />

      
      <q-card class="my-card" flat bordered>
      <q-img src="https://cdn.quasar.dev/img/chicken-salad.jpg" />

      <q-card-section>
        <q-btn
          fab
          color="primary"
          icon="place"
          class="absolute"
          style="top: 0; right: 12px; transform: translateY(-50%);"
        />

        <div class="row no-wrap items-center">
          <div class="col text-h6 ellipsis">
            Cafe Basilico
          </div>
          <div class="col-auto text-grey text-caption q-pt-md row no-wrap items-center">
            <q-icon name="place" />
            250 ft
          </div>
        </div>

        <q-rating v-model="stars" :max="5" size="32px" />
      </q-card-section>

      <q-card-section class="q-pt-none">
        <div class="text-subtitle1">
          $・Italian, Cafe
        </div>
        <div class="text-caption text-grey">
          Small plates, salads & sandwiches in an intimate setting.
        </div>
      </q-card-section>

      <q-separator />

      <q-card-actions>
        <q-btn flat round icon="event" />
        <q-btn flat color="primary">
          Reserve
        </q-btn>
      </q-card-actions>
    </q-card>
  </div> --
    <-- </q-parallax> --

    <-- </div> --
  </main> -->
</template>

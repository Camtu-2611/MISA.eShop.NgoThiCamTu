<template>
  <div class="alert-modal">
    <!-- <div class="t-icon icon-warning"></div> -->
    <div class="alert-form">
      <div class="alert-text">Vui lòng chọn bản ghi</div>
    </div>
  </div>
</template>

<script>
export default {
  props:{
    visible: Boolean,
  },
  data() {
    return {
      
    };
  },
  methods: {
    hide() {
      this.visible = false;
    },
    show() {
      this.visible = true;
    },
  },
};
</script>

<style scoped>
.alert-modal {
  width: fit-content;
  min-width: 250px;
  height: fit-content;
  min-height: 30px;
  color: #ffffff;
  font-size: 15px;
  background-color: #f34b3f;
  border-radius: 3px;
  opacity: 0.9;
  z-index: 1000;
  box-shadow: inset 0 1px 1px rgb(0 0 0 / 16%), 0 0 1px rgb(1 1 2 / 15%);
  display: flex;
  padding: 10px;
  position: fixed;
  top: 14px;
  left: calc(50% - 125px);
  align-items: center;
}

.alert-btn-ok {
  margin-left: 15px;
  color: white;
  font-weight: bold;
  float: right;
  font-size: 22px;
  line-height: 20px;
  cursor: pointer;
  transition: 0.3s;
}

.alert-btn-ok:hover{
    color: #000;
}
</style>
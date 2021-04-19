<template>
  <div class="alert-modal" >
    <div class="alert-left"></div>
    <div class="alert-form">
      <div class="alert-text">{{alertMessage}}</div>
    </div>
  </div>
</template>

<script>
export default {
  props:{
    visible: Boolean,
    alertMessage: String,
  },
  data() {
    return {
      
    };
  },
  methods: {
    /**
     * Sự kiện ẩn thông báo
     * CreatedBy: nctu 19.04.2021
     */
    hide() {
      this.visible = false;
    },

    /**
     * Sự kiện hiện form thông báo
     * CreatedBy: nctu 19.04.2021
     */
    show() {
      this.visible = true;
    },

  },
};
</script>

<style scoped>
.success{
  background-color: #187d1e;
}
.fail{
  background-color: #ffe7af;
}


.alert-modal {
  width: fit-content;
  min-width: 250px;
  height: fit-content;
  min-height: 30px;
  color: #000;
  font-size: 15px;
  background-color: #ffe7af;
  border-radius: 3px;
  opacity: 0.9;
  z-index: 1000;
  box-shadow: 0 3px 6px rgb(0 0 0 / 16%), 0 3px 6px rgb(1 1 2 / 15%);
  display: flex;
  padding: 10px;
  position: fixed;
  top: 14px;
  left: calc(50% - 125px);
  align-items: center;
}

.alert-left{
  width: 15px;
  height: fit-content;
  background-color: #187d1e;
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
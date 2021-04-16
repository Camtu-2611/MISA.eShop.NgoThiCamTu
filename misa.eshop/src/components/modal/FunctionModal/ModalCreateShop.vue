<template>
  <BaseModalForm ref="BaseForm_ref">
    <div class="dialog-form form-add-edit">
      <div class="dialog-header">
        <div class="dialog-header-content">
          <div class="dialog-title" id="dialog-title">Thêm mới cửa hàng</div>
          <div class="dialog-button">
            <button
              class="t-btn btn-close t-icon"
              id="btn-close"
              @click="hide()"
            ></button>
          </div>
        </div>
      </div>
      <div class="dialog-add-edit">
        <div class="dialog-content-top">
          <div class="form-group t-row">
            <p class="label-text text-one-line">
              Mã cửa hàng<span class="text-color-red">&nbsp;*</span>
            </p>
            <input
              class="form-control t-input"
              required
              tabindex="1"
              :class="{ 'boder-warning': !validate.storeCode }"
              v-model="selectedShop.storeCode"
              @blur="validateStoreCode()"
            />
            <span v-show="!validate.storeCode" class="warning">
              <span class="tooltiptext">{{warningMsg}}</span>
            </span>
          </div>
          <div class="form-group t-row">
            <p class="label-text text-one-line">
              Tên cửa hàng<span class="text-color-red">&nbsp;*</span>
            </p>
            <input
              class="form-control t-input"
              required
              tabindex="2"
              :class="{ 'boder-warning': !validate.storeName }"
              v-model="selectedShop.storeName"
              @blur="validateStoreName()"
            />
            <span v-show="!validate.storeName" class="warning">
              <span class="tooltiptext">{{warningMsg}}</span>
            </span>
          </div>
          <div class="form-group t-row">
            <p class="label-text text-one-line">
              Địa chỉ<span class="text-color-red">&nbsp;*</span>
            </p>
            <textarea
              class="form-control t-input"
              id="txt-address"
              required
              rows="4"
              tabindex="3"
              :class="{ 'boder-warning': !validate.address }"
              v-model="selectedShop.address"
              @blur="validateAddress()"
            >
            </textarea>
            <span v-show="!validate.address" class="warning">
              <span class="tooltiptext">{{warningMsg}}</span>
            </span>

          </div>
        </div>
        <div class="dialog-content-bottom">
          <div class="t-row">
            <div class="form-group col-50">
              <p class="label-text text-one-line">Số điện thoại</p>
              <input
                class="form-control t-input"
                tabindex="4"
                v-model="selectedShop.phoneNumber"
              />
            </div>
            <div class="form-group col-50">
              <p class="label-text text-one-line">Mã số thuế</p>
              <input
                class="form-control t-input"
                tabindex="5"
                v-model="selectedShop.storeTaxCode"
              />
            </div>
          </div>
          <div class="t-row">
            <div class="form-group col-50">
              <p class="label-text text-one-line">Quốc gia</p>
              <select
                class="form-control t-input"
                tabindex="6"
                v-model="selectedCountry"
              >
                <option
                  v-for="item in country"
                  :key="item.value"
                  v-bind:value="item.value"
                >
                  {{ item.text }}
                </option>
              </select>
            </div>
            <div class="form-group col-50"></div>
          </div>
          <div class="t-row">
            <div class="form-group col-50">
              <p class="label-text text-one-line">Tỉnh/Thành phố</p>
              <select
                class="form-control t-input"
                tabindex="7"
                v-model="selectedProvince"
                :disabled="!selectedCountry"
              >
                <option
                  v-for="item in province"
                  :key="item.value"
                  :value="item.value"
                >
                  {{ item.text }}
                </option>
              </select>
            </div>
            <div class="form-group col-50">
              <p class="label-text text-one-line">Quận/Huyện</p>
              <select
                class="form-control t-input"
                tabindex="8"
                v-model="selectedDistrict"
                :disabled="!selectedProvince"
              >
                <option
                  v-for="item in district"
                  :key="item.value"
                  v-bind:value="item.value"
                >
                  {{ item.text }}
                </option>
              </select>
            </div>
          </div>
          <div class="t-row">
            <div class="form-group col-50">
              <p class="label-text text-one-line">Phường/Xã</p>
              <select
                class="form-control t-input"
                tabindex="9"
                v-model="selectedShop.wardId"
                :disabled="!selectedDistrict"
              >
                <option
                  v-for="item in ward"
                  :key="item.value"
                  v-bind:value="item.value"
                >
                  {{ item.text }}
                </option>
              </select>
            </div>
            <div class="form-group col-50">
              <p class="label-text text-one-line">Đường phố</p>
              <input
                class="form-control t-input"
                tabindex="10"
                v-model="selectedShop.street"
              />
            </div>
          </div>
        </div>
        <!-- <div class="dialog-content">
          
        </div> -->
      </div>
      <div class="dialog-footer footer-add-edit">
        <div class="dialog-footer-left">
          <button
            class="t-btn dialog-btn-help"
            id="btn-help-dialog"
            tabindex="14"
          >
            <i class="t-icon t-icon-help"></i>
            <span class="dialog-help-text">Trợ giúp</span>
          </button>
        </div>
        <div class="dialog-footer-right">
          <button
            class="t-btn d-btn btn-save"
            id="btn-save"
            tabindex="11"
            @click="save()"
          >
            <div class="t-icon icon-save"></div>
            <span>Lưu</span>
          </button>
          <button
            class="t-btn d-btn btn-save-add"
            id="btn-save-add"
            tabindex="12"
            @click="saveAndAdd()"
          >
            <div class="t-icon icon-save-add"></div>
            <span>Lưu và thêm mới</span>
          </button>
          <button
            class="t-btn d-btn btn-cancel"
            id="cancel"
            tabindex="13"
            @click="hide()"
          >
            <div class="t-icon icon-cancel"></div>
            <span>Hủy bỏ</span>
          </button>
        </div>
      </div>
    </div>
  </BaseModalForm>
</template>

<script>
import axios from "axios";
import BaseModalForm from "../BaseModalForm";
export default {
  components: {
    BaseModalForm,
  },
  props: {
    msg: String,
    selectedShop: Object,
  },

  data() {
    return {
      shop: {
        // storeId: null,
        storeCode: "",
        storeName: "",
        address: "",
        phoneNumber: "",
        storeTaxCode: "",
        countryId: null,
        provinceId: null,
        districtId: null,
        wardId: null,
        status: 0,
        street: "",
        createDate: new Date(),
        createUserId: "149fb958744f70c67709bf1378b8dc91",
      },

      country: [
        {
          text: "Chọn quốc gia",
          value: "0",
        },
      ],
      province: [
        {
          text: "Chọn tỉnh/thành phố",
          value: "0",
        },
      ],
      district: [
        {
          text: "Chọn quận/huyện",
          value: "0",
        },
      ],
      ward: [
        {
          text: "Chọn phường/xã",
          value: "0",
        },
      ],

      selectedCountry: "",
      selectedProvince: "",
      selectedDistrict: "",
      selectedWard: "",
      warningMsg:"",
      inputBlur: true,
      validate: {
        storeCode: true,
        storeName: true,
        address: true,
      },
    };
  },

  methods: {
    /**
     * Ẩn dialog
     */
    hide() {
      //   this.$emit('closeDialog');
      this.$refs.BaseForm_ref.hide();
      this.validate.storeCode = true;
      this.validate.storeName = true;
      this.validate.address = true;
      this.selectedCountry = null;
      this.selectedProvince = null;
      this.selectedDistrict = null;
    },
    /**
     * Hiện dialog
     */
    show() {
      this.selectedCountry = this.selectedShop.countryId;
      this.selectedProvince = this.selectedShop.provinceId;
      this.selectedDistrict = this.selectedShop.districtId;
      this.$refs.BaseForm_ref.show();
      this.getCountryData();
      
    },
    /**
     * Lưu thông tin khi thêm hoặc sửa
     * CreatedBy: nctu 15.04.2021
     */
    save() {
      let message ="";
      switch (this.msg) {
        case "post":{
          if (this.validateForm()) {
            this.selectedShop.countryId= this.selectedCountry;
            this.selectedShop.provinceId = this.selectedProvince;
            this.selectedShop.districtId = this.selectedDistrict;
            this.shop = this.selectedShop;
            this.$delete(this.shop, 'storeId');

            axios
              .post("http://localhost:35480/api/v1/stores/", this.shop)
              .then((respone) => {
                console.log(`success ${respone.data}`);
                message = `Thêm ${this.shop.storeName}`
                this.$emit("createdDone",message);
              })
              .catch((error) => console.log(error.data.devMsg));
                
             }
          break;
        }
        case "put":{
          if (this.validateForm()) {
            this.selectedShop.countryId= this.selectedCountry;
            this.selectedShop.provinceId = this.selectedProvince;
            this.selectedShop.districtId = this.selectedDistrict;
            
            axios
              .put(`http://localhost:35480/api/v1/stores/${this.selectedShop.storeId}`, this.selectedShop)
              .then((respone) => {
                console.log(`success ${respone.data}`);
                message = "Cập nhật thành công";
                this.$emit("createdDone",message);
              })
              .catch((error) => {
                console.log(error.data);
              });
             }
          break;
        }
      }
    },
    /**
     * Lấy danh sách quốc gia từ api
     * createdBy: nctu 15.04.2021
     */
    getCountryData() {
      axios
        .get("http://localhost:35480/api/v1/Countrys")
        .then((respone) => {
          var option = [
            {
              text: "Chọn Quốc gia",
              value: "",
            },
          ];
          respone.data.data.forEach((element) => {
            option.push({
              text: element.countryName,
              value: element.countryId,
            });
          });
          this.country = option;
        })
        .catch((error) => console.log(error));
    },
    /**
     * lấy danh sách tỉnh/thành phố theo quốc gia
     * createdBy: nctu 15.04.2021
     */
    getProvinceData() {
      console.log(this.selectedCountry)
      axios
        .get(
          `http://localhost:35480/api/v1/Provinces/WithCountry/${this.selectedCountry}`
        )
        .then((respone) => {
          var option = [
            {
              text: "Chọn Tỉnh/ Thành phố",
              value: "",
            },
          ];
          respone.data.data.forEach((element) => {
            option.push({
              text: element.provinceName,
              value: element.provinceId,
            });
          });
          this.province = option;
        })
        .catch((error) => console.log(error));
    },
    /**
     * lấy danh sách quận/huyện theo tỉnh/thành phố
     * createdBy: nctu 15.04.2021
     */
    getDistrictData() {
      axios
        .get(
          `http://localhost:35480/api/v1/Districts/WithProvince/${this.selectedProvince}`
        )
        .then((respone) => {
          var option = [
            {
              text: "Chọn quận/huyện",
              value: "",
            },
          ];
          respone.data.data.forEach((element) => {
            option.push({
              text: element.districtName,
              value: element.districtId,
            });
          });
          this.district = option;
        })
        .catch((error) => console.log(error));
    },
    /**
     * lấy danh sách phường/xã theo quận/huyện
     * createdBy: nctu 15.04.2021
     */
    getWardData() {
      axios
        .get(
          `http://localhost:35480/api/v1/Wards/WithDistrict/${this.selectedDistrict}`
        )
        .then((respone) => {
          var option = [
            {
              text: "Chọn Phường/Xã",
              value: "",
            },
          ];
          respone.data.data.forEach((element) => {
            option.push({
              text: element.wardName,
              value: element.wardId,
            });
          });
          this.ward = option;
        })
        .catch((error) => console.log(error));
    },
    // hiện thông báo thành công sau khi thêm hoặc sửa
    showAlertSuccess(){
      //hiện thông báo thành công sau khi thêm hoặc sửa
    },

    // reset dữ liệu trong form
    resetForm: function () {
      this.selectedShop.storeId = null
      this.selectedShop.storeCode = "";
      this.selectedShop.storeName = "";
      this.selectedShop.address = "";
      this.selectedShop.phoneNumber = "";
      this.selectedShop.storeTaxCode = "";
      this.selectedShop.wardId = null;
      this.selectedShop.street = "";
      
      this.selectedCountry = "";
      this.selectedProvince = "";
      this.selectedDistrict = "";
    },

    /**
     * Validate dữ liệu khi thêm và sửa
     * CreatedBy: nctu 15.04.2021
     * ModifiedBy: nctu 16.04.2021
     */
    validateForm() {
      if (
        this.validateStoreCode() ||
        this.validateStoreName() ||
        this.validateAddress()
      ) {
        return true;
      }
      return false;
    },
    /**
        Kiểm tra mã cửa hàng: trống hoặc trùng
        CreatedBy: nctu 16.04.2021
     */
    validateStoreCode() {
      var valid = true;
      if (this.selectedShop.storeCode == "" || this.selectedShop.storeCode == null) {
        this.validate.storeCode = false;
        this.warningMsg="Trường này không được để trống";
        valid = false;
      } else if (this.checkDuplicateCode(this.selectedShop.storeCode)) {
        this.validate.storeCode = false;
         this.warningMsg="Mã cửa hàng đã tồn tại trong hệ thống";
        valid = false;
      } else {
        this.validate.storeCode = true;
        valid = true;
      }
      return valid;
    },
    /**
        Kiểm tra tên cửa hàng xem có trống không
        CreatedBy: nctu 16.04.2021
     */
    validateStoreName() {
      let valid = true;
      if (this.selectedShop.storeName == "" || this.selectedShop.storeName == null) {
        this.validate.storeName = false;
         this.warningMsg="Trường này không được để trống";
        valid = false;
      } else {
        this.validate.storeName = true;
        valid = true;
      }
      return valid;
    },
    /**
        Kiểm tra địa chỉ
        CreatedBy: nctu 16.04.2021
     */
    validateAddress() {
      let valid = true;
      if (this.selectedShop.address == "" || this.selectedShop.address == null) {
        this.validate.address = false;
         this.warningMsg="Trường này không được để trống";
        valid = false;
      } else {
        this.validate.address = true;
        valid = true;
      }
      return valid;
    },
    /**
     * Kiểm tra mã cửa hàng xem có bị trùng hay không
     * createdBy: ntu 15.04.2021
     */
    checkDuplicateCode(storeCode) {
      axios
        .get("http://localhost:35480/api/v1/stores/", {
          params: {
            storeCode: storeCode,
          },
        })
        .then((respone) => {
          console.log(respone.data.errorCode);
          var errorCode = respone.data.errorCode;
          if (errorCode == 400) return false;
          else if (errorCode == 0) return true;
        })
        .catch((error) => console.log(error));
    },
  },

  watch: {
    selectedCountry(val) {
      if(val) {
        this.getProvinceData();
      }
    },
    selectedProvince(val) {
     
     if(val) {
       this.getDistrictData();
      }
    },
    selectedDistrict(val) {
       if(val) {
      this.getWardData();
      }
      
    },
    
    // selectedWard(val) {
    //   this.selectedWard = val
    // }
  },
};
</script>

<style>
/* @import "../../../styles/dialog.css"; */
.tooltiptext{
  visibility: hidden;
  width: 220px;
  line-height: 20px;
  background-color: #df4646;
  color: #fff;
  text-align: center;
  border-radius: 3px;
  padding: 5px 0;
  position: absolute;
  z-index: 1;
  bottom: 0;
  left: 85px;
  margin-left: -60px;

}

.warning:hover .tooltiptext {
  visibility: visible;
}
</style>
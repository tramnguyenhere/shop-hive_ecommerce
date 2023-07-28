import { useForm } from "react-hook-form";

import { AddressType } from "../../types/Address";

const AddressForm = ({ cartId }: { cartId?: string }) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<AddressType>();

  const onSubmit = (data: AddressType) => {
    // console.log(data, cartId);
  };

  return (
    <form className="form" onSubmit={handleSubmit(onSubmit)}>
      <div className="form__group">
        <input
          type="text"
          placeholder="Enter your name"
          {...register("name", { required: true })}
        />
        {errors.name && (
          <span className="form--error">This field is required!</span>
        )}
      </div>
      <div className="form__group">
        <input
          type="email"
          placeholder="Enter your email"
          {...register("email", { required: true, pattern: /^\S+@\S+$/i })}
        />
        {errors.email && (
          <span className="form--error">
            This field is required to put a valid email!
          </span>
        )}
      </div>
      <div className="form__group">
        <input
          maxLength={15}
          type="tel"
          placeholder="Enter your phone"
          {...register("phone", { required: true, maxLength: 15 })}
        />
        {errors.phone && (
          <span className="form--error">
            This field is required to put a valid phone number!
          </span>
        )}
      </div>
      <div className="form__group">
        <input
          type="text"
          placeholder="Enter your street"
          {...register("street", { required: true })}
        />
        {errors.street && (
          <span className="form--error">
            This field is required to put a street address!
          </span>
        )}
      </div>
      <div className="form__group">
        <input
          type="text"
          placeholder="Enter your city"
          {...register("city", { required: true })}
        />
        {errors.city && (
          <span className="form--error">
            This field is required to put a city name!
          </span>
        )}
      </div>
      <div className="form__group">
        <input
          type="text"
          placeholder="Enter your postal code"
          {...register("postalCode", { required: true })}
        />
        {errors.postalCode && (
          <span className="form--error">
            This field is required to put a postal code address!
          </span>
        )}
      </div>
      <div className="form__group">
        <input
          type="text"
          placeholder="Enter your country"
          {...register("country", { required: true })}
        />
        {errors.country && (
          <span className="form--error">
            This field is required to put a country name!
          </span>
        )}
      </div>

      <button type="submit" className="form__button">
        Pay for your order
      </button>
    </form>
  );
};

export default AddressForm;

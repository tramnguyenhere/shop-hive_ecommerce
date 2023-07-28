import React, { useState } from "react";

import useAppSelector from "../../hooks/useAppSelector";
import useAppDispatch from "../../hooks/useAppDispatch";
import { UserUpdate } from "../../types/UserUpdate";
import { updateUser } from "../../redux/reducers/usersReducer";

const EditUserForm = ({
  setEditPageVisible,
}: {
  setEditPageVisible: React.Dispatch<React.SetStateAction<boolean>>;
}) => {
  const currentUser = useAppSelector((state) => state.users.currentUser);
  const [name, setName] = useState(currentUser?.name || "");
  const [email, setEmail] = useState(currentUser?.email || "");
  const [password, setPassword] = useState(currentUser?.password || "");
  const [avatar, setAvatar] = useState(currentUser?.avatar || "");

  const dispatch = useAppDispatch();

  const editFormHandler = (e: any) => {
    e.preventDefault();
    if (currentUser) {
      const updatedUser: UserUpdate = {
        id: Number(currentUser.id),
        update: { role: currentUser.role, name, email, password, avatar },
      };
      dispatch(updateUser(updatedUser));
      setEditPageVisible(false);
    }
  };
  return (
    <form className="form" onSubmit={editFormHandler}>
      <div className="form__group">
        <h3 className="user-profile--edit__section__header">Name</h3>
        <input
          placeholder="Change Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
      </div>
      <div className="form__group">
        <h3 className="user-profile--edit__section__header">Email</h3>
        <input
          placeholder="Change Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>
      <div className="form__group">
        <h3 className="user-profile--edit__section__header">Password</h3>
        <input
          placeholder="Change Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </div>
      <div className="form__group">
        <h3 className="user-profile--edit__section__header">Avatar</h3>
        <input
          placeholder="Change Avatar"
          value={avatar}
          onChange={(e) => setAvatar(e.target.value)}
        />
      </div>
      <button className="full-width-button__primary " type="submit">
        Save
      </button>
    </form>
  );
};

export default EditUserForm;

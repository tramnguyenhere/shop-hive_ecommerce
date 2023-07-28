import React, { useState } from "react";

import useAppSelector from "../hooks/useAppSelector";
import useAppDispatch from "../hooks/useAppDispatch";
import Helmet from "../components/Helmet";
import EditUserForm from "../components/Form/EditUserForm";
import { logout } from "../redux/reducers/usersReducer";

const UserProfile = () => {
  const currentUser = useAppSelector((state) => state.users.currentUser);

  const [editPageVisible, setEditPageVisible] = useState(false);
  const dispatch = useAppDispatch();

  return (
    <Helmet title="User Profile">
      <div>
        <h2 className="page__header">{currentUser?.role.toUpperCase()}</h2>
        {editPageVisible ? (
          <div className="user-profile--edit">
            <EditUserForm setEditPageVisible={setEditPageVisible} />
          </div>
        ) : (
          <div className="user-profile">
            <div className="user-profile__section">
              <img src={currentUser?.avatar} alt="avatar" />
            </div>
            <div className="user-profile__section">
              <h3>Name: </h3>
              <p>{currentUser?.name}</p>
            </div>
            <div className="user-profile__section">
              <h3>Email: </h3>
              <p>{currentUser?.email}</p>
            </div>
            <div className="user-profile__section">
              <button
                className="fit-button__secondary"
                onClick={() => setEditPageVisible(true)}
              >
                Edit
              </button>
              <button
                className="fit-button__primary"
                onClick={() => dispatch(logout())}
              >
                Logout
              </button>
            </div>
          </div>
        )}
      </div>
    </Helmet>
  );
};

export default UserProfile;

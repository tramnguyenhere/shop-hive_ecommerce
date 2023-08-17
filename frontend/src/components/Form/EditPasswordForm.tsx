import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const EditPasswordForm = () => {
    const navigate = useNavigate();

    const [newPassword, setNewPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [passwordsMatch, setPasswordsMatch] = useState(true);

    const handleConfirmPasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setConfirmPassword(e.target.value);
        if (newPassword !== e.target.value && confirmPassword !== '' ) {
            setPasswordsMatch(false);
        } else {
            setPasswordsMatch(true);
        }
    };

    const saveChangeHandler = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        if (!passwordsMatch) {
            return; 
        }
    };

    const exit = () => {
        navigate('/user');
    };

    return (
        <form className='form' onSubmit={saveChangeHandler}>
            <div className='form__group'>
                <h3 className='user-profile--edit__section__header'> Enter your new password</h3>
                <input
                    placeholder='Change'
                    value={newPassword}
                    onChange={e=>setNewPassword(e.target.value)}
                />
            </div>
            <div className='form__group'>
                <h3 className='user-profile--edit__section__header'>
                    Confirm your new password
                </h3>
                <input
                    placeholder='Change'
                    value={confirmPassword}
                    onChange={handleConfirmPasswordChange}
                />
                {!passwordsMatch && (
                    <p className='error-message'>Passwords do not match</p>
                )}
            </div>
            <div className=''>
                <button
                    className='full-width-button__primary'
                    type='submit'
                    disabled={!passwordsMatch}
                >
                    Save
                </button>
                <button
                    className='full-width-button__secondary'
                    onClick={exit}
                >
                    Back
                </button>
            </div>
        </form>
    );
};

export default EditPasswordForm;

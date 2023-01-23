export const Validation = {
    nameValidation: /^[a-zA-Z]{2,100}/,
    userNameValidation: /^[A-Za-z._-\d]{5,100}/,
    emailValidation: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,100}$/i,
    passwordValidation: /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{9,20}$/
}
export const Validation = {
    userValidations: {
        nameValidation: /^[A-Za-z].{1,20}$/,
        userNameValidation: /^[A-Za-z._-\d]{5,100}/,
        emailValidation: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,100}$/i,
        passwordValidation: /^(?=.*[0-9])(?=.*[!@#F$%^&*])[a-zA-Z0-9!@#$%^&*]{9,20}$/,
    },
    listingValidations: {
        listingTitleValidation: /^[A-Za-z._-\d ].{10,50}$/,
        listingDescriptionValidation: /^[A-Za-z._-\d ].{40,200}$/,
        carMakeModelColorValidation: /^[A-Za-z._-\d ].{1,15}$/,
        listingLocationValidation: /^[A-Za-z].{1,20}$/,
        listingEngineDisplacementValidation: /^\d{1}.\d{1}$/,
        listingEngineLayoutValidation: /^[A-Z]{1}\d{1,2}$/,
        listingYearOfProductionValidation: /^\d{4}$/,
        listingMileagePriceValidation: /\d/,
    }
}
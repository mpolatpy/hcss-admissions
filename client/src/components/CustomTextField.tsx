import React from 'react';
import {useField} from 'formik';
import TextField from '@mui/material/TextField';

interface Props {
    label: string;
    variant?: 'standard' | 'outlined' | 'filled' | undefined;
    name: string;
}

const CustomTextField = (props: Props) => {
    const {name, variant, label} = props;
    const [field, meta] = useField(name);

    return (
        <TextField 
            error={meta.touched && !!meta.error}
            label={label}
            {...field} 
            variant={variant}
            helperText={ meta.touched && meta.error ? meta.error : null }
            fullWidth
        />
    )
};

export default CustomTextField;
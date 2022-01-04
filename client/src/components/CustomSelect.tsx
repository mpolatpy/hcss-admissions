import React from 'react';
import {useField} from 'formik';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import FormHelperText from '@mui/material/FormHelperText';

interface Props {
    label: string;
    variant?: 'standard' | 'outlined' | 'filled' | undefined;
    options: string[];
    name: string;
}

const CustomSelect = (props: Props) => {
    const {name, label, variant, options} = props;
    const [field, meta] = useField(name);

    return (

        <FormControl error={meta.touched && !!meta.error} fullWidth variant={variant}>
            <InputLabel id={`select-for-${label}-label`}>{label}</InputLabel>
            <Select
                labelId={`select-for-${label}-label`}
                id={`select-for-${label}`}
                {...field}
                {...props}
            >
                <MenuItem value="">
                    <em>{''}</em>
                </MenuItem>
                {
                    options.map((option, index) => (
                        <MenuItem key={index} value={option}>{option}</MenuItem>
                    ))
                }
            </Select>
            {meta.touched && meta.error ? (
                <FormHelperText>{meta.error}</FormHelperText>
            ) : null}
        </FormControl >

    );
}

export default CustomSelect;